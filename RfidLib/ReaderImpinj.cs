using CommonLib.Devices;
using Impinj.OctaneSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RfidReaderLibrary
{
    public class ReaderImpinj : IRfidReader
    {
        internal ImpinjReader impinjReader;
        internal Settings settings;

        private volatile bool _isReading;

        public ReaderImpinj()
        {
            impinjReader = new ImpinjReader
            {
                ConnectTimeout = 6000,
            };

            Antennas = new int[] { 4, 5 };
            _isReading = false;
        }

        public ReaderImpinj(string address)
            :this()
        {
            Address = address;
        }



        public string Address { get; set; }

        public int[] Antennas { get; set; }
        public bool IsReading => impinjReader != null && _isReading;

        public bool IsConnected => impinjReader != null && impinjReader.IsConnected;

        public event EventHandler<ReaderEventArgs> TagsEventSender;
        public event Action<ConnectionState> OnConnectionState;

        
        public async Task Connect()
        {
            await Task.Run(() =>
           {
               try
               {
                   impinjReader.Connect(Address);
                   Console.WriteLine("Reader Impinj Connected");
                   ApplySettings();
                   Console.WriteLine("Reader Impinj Settings Applied");
               }
               catch (OctaneSdkException ex)
               {
                   Console.WriteLine(ex.Message);
                   return false;
                }
               catch (Exception ex)
               {
                   Console.WriteLine("Exception {0}", ex);
                   return false;
                }

               return true;
           });

        }

        public void ApplySettings()
        {
            try
            {
                Console.WriteLine("Starting Configuration...");
                impinjReader.ApplyDefaultSettings();

                settings = impinjReader.QueryDefaultSettings();

                settings.TagPopulationEstimate = 50;

                Console.WriteLine("Setting Session 0");

                settings.Session = 1;
                settings.ReaderMode = ReaderMode.AutoSetStaticFast;

                settings.SearchMode = SearchMode.SingleTarget;

                Console.WriteLine(" Setting Automode...");
                settings.AutoStart.Mode = AutoStartMode.None;
                settings.AutoStop.Mode = AutoStopMode.None;



                Console.WriteLine("Setting Report Mode...");
                settings.Report.Mode = ReportMode.Individual;
                settings.Report.IncludeAntennaPortNumber = true;
                settings.Report.IncludeSeenCount = true;
                settings.Report.IncludePeakRssi = true;
                settings.Report.IncludeChannel = false;
                settings.Report.IncludeFirstSeenTime = false;
                settings.Report.IncludeLastSeenTime = false;
                settings.Report.IncludePhaseAngle = false;


                SettingAntennas();

                impinjReader.ApplySettings(settings);

                Console.WriteLine("All Set!");

                impinjReader.TagsReported += TagsReportedHandler;
            }
            catch (OctaneSdkException ex)
            {
                Console.WriteLine("OctaneSdk detected {0}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail to setup {0}", ex);
            }

        }

        private void TagsReportedHandler(object sender, TagReport e)
        {
            try
            {
                var tags = e.Tags;

                if (TagsEventSender != null)
                {
                    //var tDistinct = tags.Select(td => td.Epc).Distinct();
                    var send = new Dictionary<string, Tuple<double, int>>();
                    foreach (var t in tags)
                    {
                        if (!send.ContainsKey(t.Epc.ToHexString()))
                        {
                            var elements = tags.Where(x => x.Epc == t.Epc);
                            var avg = elements.Average(y => y.PeakRssiInDbm);
                            var tuple = new Tuple<double, int>(avg, t.AntennaPortNumber);
                            send.Add(t.Epc.ToHexString(), tuple);
                        }
                    }

                    TagsEventSender(this, new ReaderEventArgs(send, DateTime.UtcNow));
                }

            }
            catch(Exception ex)
            {

            }
        }

        private void SettingAntennas()
        {
            foreach (var antenna in settings.Antennas.AntennaConfigs)
            {
                antenna.IsEnabled = false;
            }

            for (int i = 0; i < Antennas.Length; i++)
            {
                settings.Antennas.GetAntenna((ushort)Antennas[i]).IsEnabled = true;
                settings.Antennas.GetAntenna((ushort)Antennas[i]).TxPowerInDbm = 25;
                Console.WriteLine("Enabling antenna {0} with 25 dbm", Antennas[i]);
            }
        }

        public async Task Disconnect()
        {
            await Task.Run(() =>
            {
                try
                {
                    impinjReader.Disconnect();
                }
                catch (OctaneSdkException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception {0}", ex);
                }
            });
        }

        public async Task StartReading()
        {
            await Task.Run(() =>
            {
                try
                {
                    if (IsConnected)
                    {
                        impinjReader.Start();
                        _isReading = true;
                    }
                }
                catch (OctaneSdkException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception {0}", ex);
                    return false;
                }
                return true;
            });
        }

        public async Task StopReading()
        {
            await Task.Run(() =>
            {
                try
                {
                    if (IsConnected)
                    {
                        impinjReader.Stop();
                        _isReading = false;
                    }
                }
                catch (OctaneSdkException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception {0}", ex);
                    return false;
                }
                return true;
            });
        }
    }
}

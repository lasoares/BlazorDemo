using RfidReaderLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib.Devices;
using DemoWinForms.ExtensionMethods;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Client;
using System.Threading;
using System.Text.Json;
using CommonLib.Models;

namespace DemoWinForms
{
    public partial class MainForm : Form
    {

        private static ReaderImpinj _readerImpinj;
        
        private static MqttFactory _mqttFactory;
        private static IMqttClient _mqttClient;
        private static IMqttClientOptions _mqttOptions;
        private int _totalReads;
        private int _totalEpcs;

        public MainForm()
        {
            InitializeComponent();

            _readerImpinj = new ReaderImpinj(txtAddress.Text);


            // Create a new MQTT client.
            _mqttFactory = new MqttFactory();
            _mqttClient = _mqttFactory.CreateMqttClient();
            _mqttOptions = new MqttClientOptionsBuilder()
                            .WithWebSocketServer(string.Format("{0}:8083/mqtt",txtMqtt.Text))
                            .Build();

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (!_readerImpinj.IsConnected)
            {
                _readerImpinj.Connect();
            }
            
            if (!_mqttClient.IsConnected)
            {
                _mqttClient.ConnectAsync(_mqttOptions, CancellationToken.None);
            }
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            if (_readerImpinj.IsConnected)
            {
                _readerImpinj.Disconnect();
            }

            if (_mqttClient.IsConnected)
            {
                _mqttClient.DisconnectAsync();
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (_readerImpinj != null && !_readerImpinj.IsReading)
            {
                _readerImpinj.TagsEventSender += _readerImpinj_TagsEventSender;
                _readerImpinj.StartReading();
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (_readerImpinj != null && _readerImpinj.IsReading)
            {
                _readerImpinj.StopReading();
                _readerImpinj.TagsEventSender -= _readerImpinj_TagsEventSender;
            }

        }


        private void _readerImpinj_TagsEventSender(object sender, ReaderEventArgs e)
        {
            if (e.EventType != ReaderEventArgs.EventsType.TAGS_REPORT)
                return;

            
            foreach (var epc in e.Tags.Keys)
            {
                this.RunInUIThread(() =>
                {
                    var rssi = e.Tags[epc].Item1;
                    var antenna = e.Tags[epc].Item2;
                    PublishEpc(epc, rssi, antenna);
                    if (listEpcs.Items.Count == 0 || !listEpcs.Items.ContainsKey(epc))
                    {
                        var item1 = new ListViewItem(new[] { epc, rssi.ToString(), antenna.ToString() });
                        item1.Name = epc;
                        listEpcs.Items.Add(item1);
                        _totalEpcs++;
                    }
                    else
                    {
                        var item_index = listEpcs.FindItemWithText(epc).Index;
                        listEpcs.Items[item_index].SubItems[1].Text = rssi.ToString();
                        listEpcs.Items[item_index].SubItems[2].Text = antenna.ToString();
                    }

                    _totalReads++;

                    lbltotalEpcs.Text = _totalEpcs.ToString();
                    lbltotalReads.Text = _totalReads.ToString();


                });
            }


        }

        private void PublishEpc(string epc, double rssi, int antenna)
        {

            var model = new TagModel
            {
                Antenna = antenna,
                Epc = epc,
                Rssi = rssi
            };

            var jsonString = JsonSerializer.Serialize(model);

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("MyTopic")
                .WithPayload(jsonString)
                .WithExactlyOnceQoS()
                .WithRetainFlag()
                .Build();

            _mqttClient.PublishAsync(message, CancellationToken.None);
        }

        private void btClear_Click(object sender, EventArgs e)
        {            
            _totalEpcs = _totalReads = 0;
            this.RunInUIThread(() =>
            {
                listEpcs.Items.Clear();
                lbltotalEpcs.Text = _totalEpcs.ToString();
                lbltotalReads.Text = _totalReads.ToString();
            });
        }
    }
}

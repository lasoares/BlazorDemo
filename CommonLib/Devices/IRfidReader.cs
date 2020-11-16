using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonLib.Devices {

	public interface IRfidReader
	{
		event EventHandler<ReaderEventArgs> TagsEventSender;

		//event Action<ConnectionState> OnConnectionState;

		string Address { get; set; }

		bool IsReading { get; }

		bool IsConnected { get; }

		Task Connect();
		
		Task Disconnect();

		Task StartReading();

		Task StopReading();

    }
}

using System;
using System.Collections.Generic;

namespace CommonLib.Devices {
    public class ReaderEventArgs : EventArgs {

        public enum EventsType { TAGS_REPORT, INVENTORY_START, INVENTORY_STOP, SENSOR_CUTTING };
        public EventsType EventType { get; private set; }

        public Dictionary<string, Tuple<double,int>> Tags { get; private set; }
        public DateTime ScannedDateTime { get; set; }
        public int GpiPort { get; set; }//hmr
        public int GpiStatus { get; set; }//hmr

        public ReaderEventArgs(Dictionary<string, Tuple<double, int>> tags, DateTime scannedDateTime)
        : base() {
            this.EventType = EventsType.TAGS_REPORT;
            this.Tags = tags;
            this.ScannedDateTime = scannedDateTime;
        }

        public ReaderEventArgs(EventsType Event, DateTime scannedDateTime)
        : base() {
            this.EventType = Event;
            this.ScannedDateTime = scannedDateTime;
        }

        //hmr
        public ReaderEventArgs(EventsType Event, DateTime GpiDateTime, int Gpiport, int Gpistatus)
            : base()
        {
            this.EventType = Event;
            this.ScannedDateTime = GpiDateTime;
            this.GpiPort = Gpiport;
            this.GpiStatus = Gpistatus;
        }
    }
}

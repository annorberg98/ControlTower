using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.EventInfo
{
    public class Takeoff : EventArgs
    {
        private string message, flight;
        private DateTime time;

        public Takeoff()
        {
            message = "Started";
            time = DateTime.Now;
        }

        public Takeoff(string flightCode) : this()
        {
            this.flight = flightCode;
        }

        public string FlightCode
        {
            get { return flight; }
            set { flight = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}

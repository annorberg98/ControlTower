using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.EventInfo
{
    public class Land : EventArgs
    {
        private DateTime time;
        private string flight;

        public Land(string flightCode)
        {
            this.time = DateTime.Now;
            this.flight = flightCode;
        }

        public string FlightCode
        {
            get { return flight; }
            set { flight = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}

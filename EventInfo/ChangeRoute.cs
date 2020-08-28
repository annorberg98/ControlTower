using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.EventInfo
{
    public class ChangeRoute : EventArgs
    {
        private DateTime time;
        private string route, flight;

        public ChangeRoute(string flightCode, string route)
        {
            this.time = DateTime.Now;
            this.flight = flightCode;
            this.route = route;
        }

        public string Route
        {
            get { return route; }
            set { route = value; }
        }

        public string Flight
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlTower
{
    public class Flight
    {
        private string flightCode;
        private string airLine;
        private string route;
        private DateTime time;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Flight() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="route"></param>
        public Flight(string code, string route)
        {
            this.flightCode = code;
            this.route = route;
            this.airLine = GetCarrierFromFlightCode(code);
        }

        /// <summary>
        /// Returns the name of the airline based on the FlightCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetCarrierFromFlightCode(string code)
        {
            string carrierString = string.Empty;         
            switch (GetCarrierPrefix(code))
            {
                case "sa":
                    carrierString = "SAS";
                    break;
                case "lh":
                    carrierString = "Lufthansa";
                    break;
                case "no":
                    carrierString = "Norwegian";
                    break;
                default:
                    carrierString = "Unknown";
                    break;
            }

            return carrierString;
        }

        /// <summary>
        /// Returns the airline prefix based on the flight code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetCarrierPrefix(string code)
        {
            string prefix = code.Substring(0, 2);
            if (Regex.IsMatch(prefix, @"^[a-zA-Z]+$"))
                return prefix.ToLower();
            else
                return "##";
        }

        /// <summary>
        /// Public property for the Flight code
        /// </summary>
        public string FlightCode
        {
            get { return flightCode; }
            set 
            {
                airLine = GetCarrierFromFlightCode(value);
                flightCode = value;
            }
        }

        /// <summary>
        /// Public property for the Flight's status
        /// </summary>
        public string Status
        {
            get { return route; }
            set { route = value; }
        }

        /// <summary>
        /// Public property for the Time
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// Public property for the Airline
        /// </summary>
        public string AirLine
        {
            get { return this.airLine; }
        }

        public override string ToString()
        {
            return $"Flight: {flightCode}";
        }
    }
}

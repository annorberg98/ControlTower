using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlTower.EventInfo;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitPlane();
        }

        /// <summary>
        /// Initilazes a plane on startup
        /// </summary>
        private void InitPlane()
        {
            tbFlightNumber.Text = "lh1234";
        }

        /// <summary>
        /// Eventhandler for "Send airplane to runway"-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFlightNumber.Text))
                MessageBox.Show("Empty");
            else
            {
                Flight flight = new Flight(tbFlightNumber.Text, "Heading for runway");
                flight.Time = DateTime.Now;

                FlightWindow newFlight = new FlightWindow(flight);
                newFlight.Show();
                newFlight.TakeoffMessage += FlightTakeoff;
                newFlight.ChangeRoute += FlightChangeRoute;
                newFlight.Landing += FlightLanding;

                Flight temp = new Flight();
                temp.FlightCode = flight.FlightCode;
                temp.Status = flight.Status;
                temp.Time = flight.Time;


                lvFlights.Items.Insert(0, temp);
            }
        }

        /// <summary>
        /// Subscriber method for Takeoff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlightTakeoff(object sender, Takeoff e)
        {
            Flight temp = new Flight();
            temp.Time = e.Time;
            temp.Status = e.Message;
            temp.FlightCode = e.FlightCode;

            lvFlights.Items.Insert(0, temp);
        }

        /// <summary>
        /// Subscriber method for ChangeRoute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlightChangeRoute(object sender, ChangeRoute e)
        {
            Flight temp = new Flight();
            temp.Time = e.Time;
            temp.Status = e.Route;
            temp.FlightCode = e.Flight;

            lvFlights.Items.Insert(0, temp);
        }

        /// <summary>
        /// Subscriber method for Landing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlightLanding(object sender, Land e)
        {
            Flight temp = new Flight();
            temp.Time = e.Time;
            temp.Status = "Flight Landed";
            temp.FlightCode = e.FlightCode;

            lvFlights.Items.Insert(0, temp);
        }
    }
}

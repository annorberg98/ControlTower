using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlTower.EventInfo;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        private string flightCode;
        private bool flightLanded = false;
        private Flight flight;

        public event EventHandler<Takeoff> TakeoffMessage;
        public event EventHandler<ChangeRoute> ChangeRoute;
        public event EventHandler<Land> Landing;

        /// <summary>
        /// Constructor
        /// </summary>
        public FlightWindow()
        {
            InitializeComponent();
            InitGui();
            flight = new Flight();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="flightNumber"></param>
        public FlightWindow(string flightNumber)
            : this()
        {
            this.flightCode = flightNumber;
            this.Title = "Flight: " + flightCode;
            SetImage(flightCode);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FlightWindow(Flight flight)
            : this()
        {
            flightCode = flight.FlightCode;
            Title = "Flight: " + flightCode;
            SetImage(flightCode);
        }

        /// <summary>
        /// Public property for the Flight code
        /// </summary>
        public string FlightCode
        {
            get { return flightCode; }
            set { flightCode = value; }
        }

        /// <summary>
        /// Sets default values for this window
        /// </summary>
        private void InitGui()
        {
            btnLand.IsEnabled = false;
            cmbBoxRoute.IsEnabled = false;
            btnStart.IsEnabled = true;
            cmbBoxRoute.ItemsSource = Enum.GetValues(typeof(Routes));
            cmbBoxRoute.SelectedIndex = 0;
        }

        /// <summary>
        /// Eventhandler for btnStart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnLand.IsEnabled = true;
            btnStart.IsEnabled = false;
            cmbBoxRoute.IsEnabled = true;
            Takeoff takeOff = new Takeoff(flightCode);
            OnTakeOff(takeOff);
        }

        /// <summary>
        /// Sets the image in the window based on the flight code
        /// </summary>
        /// <param name="code"></param>
        private void SetImage(string code)
        {
            Uri uri;
            Console.WriteLine(code);
            switch (Flight.GetCarrierPrefix(code))
            {
                case "lh":
                    uri = new Uri(@"pack://application:,,,/resources/lufthansa.jpg", UriKind.Absolute);
                    break;
                case "sa":
                    uri = new Uri(@"pack://application:,,,/resources/sas.jpg", UriKind.Absolute);
                    break;
                case "no":
                    uri = new Uri(@"pack://application:,,,/resources/norwegian.jpg", UriKind.Absolute);
                    break;
                default:
                    uri = new Uri(@"pack://application:,,,/resources/unknown.jpg", UriKind.Absolute);
                    break;
            }
            ImageSource imgSource = new BitmapImage(uri);
            imgAirline.Source = imgSource;
        }

        /// <summary>
        /// Eventhandler for btnLand
        /// </summary>
        private void btnLand_Click(object sender, RoutedEventArgs e)
        {
            Land landing = new Land(flightCode);
            OnLanding(landing);
            flightLanded = true;
            Close();
        }

        /// <summary>
        /// Publisher for the Takeoff event
        /// </summary>
        /// <param name="e"></param>
        private void OnTakeOff(Takeoff e)
        {
            if (TakeoffMessage != null)
            {
                TakeoffMessage(this, e);
            }
        }

        /// <summary>
        /// Publisher for the Land event
        /// </summary>
        /// <param name="e"></param>
        private void OnLanding(Land e)
        {
            if (Landing != null)
            {
                Landing(this, e);
            }
        }

        /// <summary>
        /// Publisher for the ChangeRouter event
        /// </summary>
        /// <param name="e"></param>
        private void OnChangedRoute(ChangeRoute e)
        {
            if (ChangeRoute != null)
            {
                ChangeRoute(this, e);
            }
        }

        /// <summary>
        /// Method that runs when the FlightWindow closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowClosing(object sender, EventArgs e)
        {
            if (!flightLanded)
            {
                ChangeRoute route = new ChangeRoute(FlightCode, "Connection lost");
                OnChangedRoute(route);
            }
        }

        /// <summary>
        /// Eventhandler for SelectedIndexChanged on cmbBoxRoute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBoxRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            Routes selected = (Routes)cmbBoxRoute.SelectedIndex;
            ChangeRoute changeRoute;
            string route = "Heading ";
            if (flightCode != null || selected != Routes.Change_Route)
            {
                switch (selected)
                {
                    case Routes.North:
                        route += Routes.North.ToString();
                        break;
                    case Routes.East:
                        route += Routes.East.ToString();
                        break;
                    case Routes.South:
                        route += Routes.South.ToString();
                        break;
                    case Routes.West:
                        route += Routes.West.ToString();
                        break;
                }
                changeRoute = new ChangeRoute(FlightCode, route);
                OnChangedRoute(changeRoute);
            }
        }

    }
}

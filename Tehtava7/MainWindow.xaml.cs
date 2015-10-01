using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace Tehtava7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Places> places;
        string selectedPlace;

        public MainWindow()
        {
            InitializeComponent();
            GetPlaces();
        }

        #region Methods
        private void Get()
        {
            foreach(Places place in places)
            {
                if (place.stationName.Equals(cmbPlaces.SelectedItem))
                {
                    selectedPlace = place.stationShortCode;
                    break;
                }
            }

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            string date = year + "-" + month + "-" + day;

            var response = new WebClient().DownloadString("http://rata.digitraffic.fi/api/v1/schedules?date=" + date);
            if (response != null)
            {
                List<Trains> trains = JsonConvert.DeserializeObject<List<Trains>>(response);
                List<Trains> rightTrains = new List<Trains>();
                foreach (Trains train in trains)
                {
                    train.right = false;
                    foreach (TrainPoints points in train.PysahdysPaikat)
                    {
                        if(points.Paikkakunta.Contains(selectedPlace))
                        {
                            train.right = true;
                        }
                        
                    }
                    if(train.right)
                    {
                        rightTrains.Add(train);
                    }
                }
                
                dgData.DataContext = rightTrains;

                dgData.Columns[1].Visibility = Visibility.Hidden;
                dgData.Columns[6].Visibility = Visibility.Hidden;
                dgData.Columns[7].Visibility = Visibility.Hidden;
            }
        }
        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            Get();
        }
        private void GetPlaces()
        {
            var response = new WebClient().DownloadString("http://rata.digitraffic.fi/api/v1/metadata/station");
            if (response != null)
            {
                places = JsonConvert.DeserializeObject<List<Places>>(response);
                foreach (Places place in places)
                {
                    if (!cmbPlaces.Items.Contains(place.stationName))
                    {
                        cmbPlaces.Items.Add(place.stationName);
                    }
                }
            }
            cmbPlaces.SelectedIndex = 0;
        }
        #endregion
    }
}

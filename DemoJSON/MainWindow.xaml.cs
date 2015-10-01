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
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace DemoJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string json = "";
        public MainWindow()
        {
            InitializeComponent();
            // http://student.labranet.jamk.fi/~salesa/mat/JsonTest
        }

        #region Methods
        private void Demo1()
        {
            // Haetaan JSON
            json = GetSimpleJSON();
            // Muunnetaan se olioiksi
            List<Person> persoonat = JsonConvert.DeserializeObject<List<Person>>(json);
            // Näytetään UI:ssa
            txtJSON.Text = json;
            dgData.DataContext = persoonat;
        }
        private void Demo2()
        {
            var response = new WebClient().DownloadString("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
            if (response != null)
            {
                List<Politic> poliitikot = JsonConvert.DeserializeObject<List<Politic>>(response);
                dgData.DataContext = poliitikot;
            } else
            {
                txtJSON.Text = "Homo!";
            }
        }
        private string GetJsonFromWeb()
        {
            var response = new WebClient().DownloadString("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
            return response;
        }
        private void Demo2ASync()
        {
            new Thread(() =>
            {
               string result = GetJsonFromWeb();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    txtJSON.Text = result;
                    List<Politic> persoonat = JsonConvert.DeserializeObject<List<Politic>>(result);
                    dgData.DataContext = persoonat;
                }));
            }).Start();
            txtJSON.Text = "Haetaan dataa webistä...";
        }
        private string GetSimpleJSON()
        {
            return @"[ {'Name':'Pasi Petteri','Gender':'Female','Birthday':'2000-11-11'},
                       {'Name':'Piotr Karcvzkkvcyk','Gender':'Male','Birthday':'1920-01-01'} ]";
        }
        #endregion

        private void btnGetJSON_Click(object sender, RoutedEventArgs e)
        {
            //Demo1();
            //Demo2();
            Demo2ASync();
        }
    }
}

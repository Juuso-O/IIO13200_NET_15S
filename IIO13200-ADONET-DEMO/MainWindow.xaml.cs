//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System;
using System.Collections.Generic;
using System.Data;
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

namespace JAMK.ICT.ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
        string currentCity = "";

    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //TODO täytetään combobox asiakkaitten maitten nimillä
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
      lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;

            cbCountries.Items.Add("Kaikki");
            string successViesti, city = "";
            DataTable dt = JAMK.ICT.JSON.JSONPlacebo2015.GetAllCustomersFromSQLServer(city, JAMK.ICT.Properties.Settings.Default.Tietokanta, JAMK.ICT.Properties.Settings.Default.Taulu, out successViesti);
            foreach (DataRow dr in dt.Rows)
            {
                if (!cbCountries.Items.Contains(dr[5].ToString())) {
                    cbCountries.Items.Add(dr[5]);
                }
            }
            cbCountries.SelectedItem = "Kaikki";
        }

    private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
        //TODO TEST
        dgCustomers.DataContext = JAMK.ICT.JSON.JSONPlacebo2015.GetTestCustomers();
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
        //TODO GET ALL
        string successViesti, city = "";
        dgCustomers.DataContext = JAMK.ICT.JSON.JSONPlacebo2015.GetAllCustomersFromSQLServer(city, JAMK.ICT.Properties.Settings.Default.Tietokanta, JAMK.ICT.Properties.Settings.Default.Taulu, out successViesti);
        lbMessages.Content = successViesti;
    }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
            //TODO GET FROM
            if(currentCity == "Kaikki")
            {
                currentCity = "";
            }
            string successViesti;
            dgCustomers.DataContext = JAMK.ICT.JSON.JSONPlacebo2015.GetAllCustomersFromSQLServer(currentCity, JAMK.ICT.Properties.Settings.Default.Tietokanta, JAMK.ICT.Properties.Settings.Default.Taulu, out successViesti);
            lbMessages.Content = successViesti;
            btnGetFrom.IsEnabled = false;
        }

        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentCity = cbCountries.SelectedItem.ToString();
            btnGetFrom.IsEnabled = true;
        }
    }
}

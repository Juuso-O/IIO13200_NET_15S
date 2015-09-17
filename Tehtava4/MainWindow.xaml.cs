using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using System.Xml.Linq;

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        string filePath = ConfigurationManager.AppSettings.Get("filePath");
        List<Viini> viinilista = new List<Viini>();
        string currentMaa;

        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show(filePath);

            if (File.Exists(filePath))
            {
                XDocument doc = XDocument.Load(filePath);
                var tmp = from viini in doc.Descendants("wine")
                          select new
                          {
                              Nimi = viini.Element("nimi").Value,
                              Maa = viini.Element("maa").Value,
                              Arvio = viini.Element("arvio").Value
                          };
                foreach (var viini in tmp)
                {
                    viinilista.Add(new Viini(viini.Nimi, viini.Maa, int.Parse(viini.Arvio)));
                }
            } else
            {
                MessageBox.Show("Ei aiempaa xml tiedostoa!");
            }

            viiniLista.ItemsSource = viinilista;
            //columnNimi.DisplayMemberBinding
        }

        private void haeViinit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentMaa = sender.ToString();
        }
    }
}

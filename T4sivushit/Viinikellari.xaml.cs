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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace T4sivushit
{
    /// <summary>
    /// Interaction logic for Viinikellari2.xaml
    /// </summary>
    public partial class Viinikellari : Window
    {
        string currentMaa;
        string filePath = ConfigurationManager.AppSettings.Get("filePath");

        public Viinikellari()
        {
            InitializeComponent();

            //string filePath = "D:/Viinit1.xml";
            DataGridTextColumn headerColumn = new DataGridTextColumn();
            headerColumn.Header = "Nimi";
            headerColumn.Binding = new Binding("nimi");
            DataGridTextColumn maaColumn = new DataGridTextColumn();
            maaColumn.Header = "Maa";
            maaColumn.Binding = new Binding("maa");
            DataGridTextColumn arvioColumn = new DataGridTextColumn();
            arvioColumn.Header = "Arvio";
            arvioColumn.Binding = new Binding("arvio");
            dgWines.Columns.Add(headerColumn);
            dgWines.Columns.Add(maaColumn);
            dgWines.Columns.Add(arvioColumn);


            if (File.Exists(filePath))
            {
                XDocument doc = XDocument.Load(filePath);
                var tmp = from viini in doc.Descendants("wine")
                          select new
                          {
                              nimi = viini.Element("nimi").Value,
                              maa = viini.Element("maa").Value,
                              arvio = viini.Element("arvio").Value
                          };
                foreach (var viini in tmp)
                {
                    if(!comboBox.Items.Contains(viini.maa))
                    {
                        comboBox.Items.Add(viini.maa);
                    }
                    dgWines.Items.Add(viini);
                }
            }
            else
            {
                MessageBox.Show("Ei aiempaa xml tiedostoa!");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dgWines.Items.Clear();

            if (File.Exists(filePath))
            {
                XDocument doc = XDocument.Load(filePath);
                var tmp = from viini in doc.Descendants("wine")
                          select new
                          {
                              nimi = viini.Element("nimi").Value,
                              maa = viini.Element("maa").Value,
                              arvio = viini.Element("arvio").Value
                          };
                foreach (var viini in tmp)
                {
                    if(viini.maa.Equals(currentMaa))
                    {
                        dgWines.Items.Add(viini);
                    }
                    
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentMaa = comboBox.SelectedItem.ToString();
            //MessageBox.Show(currentMaa);
        }
    }
}

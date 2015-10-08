using System;
using System.Collections.Generic;
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

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Palaute> palauteLista = new List<Palaute>();
        string filePath = Tehtava8.Properties.Settings.Default.address;

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(filePath))
            {
                try
                {
                    XDocument doc = XDocument.Load(filePath);
                    var tmp = from palaute in doc.Descendants("palaute")
                              select new
                              {
                                  pvm = palaute.Element("pvm").Value,
                                  tekija = palaute.Element("tekija").Value,
                                  opittu = palaute.Element("opittu").Value,
                                  haluanoppia = palaute.Element("haluanoppia").Value,
                                  hyvaa = palaute.Element("hyvaa").Value,
                                  parannettavaa = palaute.Element("parannettavaa").Value,
                                  muuta = palaute.Element("muuta").Value
                              };
                    foreach (var palaute in tmp)
                    {
                        palauteLista.Add(new Palaute(palaute.pvm, palaute.tekija, palaute.opittu, palaute.haluanoppia, palaute.hyvaa, palaute.parannettavaa, palaute.muuta));
                    }
                }
                catch (Exception e)
                {
                    // Error jeejee
                }
            } else
            {
                MessageBox.Show("Tiedostoa ei ole olemassa");
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (txtHaluanOppia.Text != "" && txtHyvaa.Text != "" && txtMuuta.Text != "" && txtNimi.Text != "" && txtOlenOppinut.Text != "" && txtParannettavaa.Text != "" && txtPVM.Text != "")
            {
                Palaute p = new Palaute(txtPVM.Text, txtNimi.Text, txtOlenOppinut.Text, txtHaluanOppia.Text, txtHyvaa.Text, txtParannettavaa.Text, txtMuuta.Text);
                palauteLista.Add(p);

                XDocument doc = new XDocument(
                    new XElement("palautteet",
                    from palaute in palauteLista
                    select new XElement("palaute",
                        new XElement("pvm", palaute.pvm),
                        new XElement("tekija", palaute.tekija),
                        new XElement("opittu", palaute.opittu),
                        new XElement("haluanoppia", palaute.haluanoppia),
                        new XElement("hyvaa", palaute.hyvaa),
                        new XElement("parannettavaa", palaute.parannettavaa),
                        new XElement("muuta", palaute.muuta)
                        )
                    )
                );
                
                try
                {
                    doc.Save(filePath);
                } catch (Exception error2)
                {
                    MessageBox.Show("Tiedosto jumissaan. kokeile uudestaan!");
                }
                
                ResultWindow results = new ResultWindow();
                results.resultDataGrid.DataContext = palauteLista;
                results.lblHaetut.Content = "Löytyi " + palauteLista.Count + " palautetta";
                results.Show();
            } else
            {
                MessageBox.Show("Täytä kaikki kentät!");
            }
        }
    }
}

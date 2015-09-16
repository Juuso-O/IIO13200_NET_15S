using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Tehtava3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Joukkue joukkue = new Joukkue();
        List<Pelaaja> pelaajalista = new List<Pelaaja>();
        int editIndex = 0;
        string filepath = ConfigurationManager.AppSettings.Get("filePath");


        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(filepath))
            {
                XDocument doc = XDocument.Load(filepath);
                var tmp = from pelaaja in doc.Descendants("Pelaaja")
                                   select new
                                   {
                                       Etunimi = pelaaja.Element("Etunimi").Value,
                                       Sukunimi = pelaaja.Element("Sukunimi").Value,
                                       Siirtohinta = pelaaja.Element("Siirtohinta").Value,
                                       Seura = pelaaja.Element("Seura").Value,
                                   };

                foreach (var pelaaja in tmp)
                {
                    pelaajalista.Add(new Pelaaja(pelaaja.Etunimi, pelaaja.Sukunimi, pelaaja.Seura, double.Parse(pelaaja.Siirtohinta)));
                }
            }
        }

        private void CmbSeura_Initialized(object sender, EventArgs e)
        {
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = joukkue.getJoukkueet();
            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void btnLuoPelaaja_Click(object sender, RoutedEventArgs e)
        {
            if (txtEtunimi.Text!="" && txtSukunimi.Text!="" && txtSiirtohinta.Text!="")
            {
                string uusiEtunimi = txtEtunimi.Text.ToString();
                string uusiSukunimi = txtSukunimi.Text.ToString();
                double uusiSiirtohinta = Double.Parse(txtSiirtohinta.Text.ToString());
                List<string> tmpSeuralist = joukkue.getJoukkueet();
                string uusiSeura = tmpSeuralist[CmbSeura.SelectedIndex];
                string uusiKokoNimi = uusiEtunimi + " " + uusiSukunimi + ", " + uusiSeura;
                bool vanhaPelaaja = false;

                if (pelaajalista.Count != 0)
                {
                    for (int i = 0; i < pelaajalista.Count; i++)
                        {
                        if (pelaajalista[i].KokoNimi == uusiKokoNimi)
                            {
                            //Pelaaja on jo olemassa
                            vanhaPelaaja = true;
                            break;
                        }
                    }
                    if (vanhaPelaaja)
                    {
                        //MessageBox.Show("Pelaaja on jo olemassa");
                        textBoxStatusBar.Text = "Pelaaja on jo olemassa!";
                    } else
                    {
                        Pelaaja uusiPelaaja = new Pelaaja(uusiEtunimi, uusiSukunimi, uusiSeura, uusiSiirtohinta);
                        pelaajalista.Add(uusiPelaaja);
                        paivitaLista();
                        tyhjennaKentat();
                    }
                } else
                {
                    Pelaaja uusiPelaaja = new Pelaaja(uusiEtunimi, uusiSukunimi, uusiSeura, uusiSiirtohinta);
                    pelaajalista.Add(uusiPelaaja);
                    paivitaLista();
                    tyhjennaKentat();
                }
            } else
            {
                //MessageBox.Show("Täytä kaikki kentät!");
                textBoxStatusBar.Text = "Täytä kaikki kentät!";
            }
        }

        public void paivitaLista()
        {
            listPelaajaLista.UpdateLayout();
            listPelaajaLista.ItemsSource = "";
            listPelaajaLista.ItemsSource = pelaajalista;
            listPelaajaLista.DisplayMemberPath = "KokoNimi";
        }

        public void tyhjennaKentat()
        {
            txtEtunimi.Text = "";
            txtSukunimi.Text = "";
            txtSiirtohinta.Text = "";
        }

        private void btnLopetus_Click(object sender, RoutedEventArgs e)
        {
            //Tallennus lopettaess xml muotoon filuun pelaajat.xml

            XDocument doc = new XDocument(
                new XElement("Pelaajat",
                from player in pelaajalista
                select new XElement("Pelaaja",
                    new XElement("Etunimi", player.EtuNimi),
                    new XElement("Sukunimi", player.SukuNimi),
                    new XElement("Siirtohinta", player.Siirtohinta),
                    new XElement("Seura", player.Seura)
                    )
                )
            );
            doc.Save(filepath);

            Environment.Exit(0);
        }

        private void txtSiirtohinta_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSiirtohinta.Text!="")
            {
                try
                {
                    double tmp = Double.Parse(txtSiirtohinta.Text);
                } catch(FormatException)
                {
                    //MessageBox.Show("Vain numeroita!");
                    textBoxStatusBar.Text = "Vain numeroita!";
                    txtSiirtohinta.Text = "";
                    txtSiirtohinta.Focus();
                }
            }
        }

        private void listPelaajaLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox tmpBox = sender as ListBox;
            Pelaaja tmpPelaaja = tmpBox.SelectedItem as Pelaaja;
            if (tmpPelaaja!=null) {
                editIndex = tmpBox.SelectedIndex;
                txtEtunimi.Text = tmpPelaaja.EtuNimi;
                txtSukunimi.Text = tmpPelaaja.SukuNimi;
                txtSiirtohinta.Text = tmpPelaaja.Siirtohinta.ToString();
                CmbSeura.Text = tmpPelaaja.Seura;
            }
        }

        private void listPelaajaLista_Initialized(object sender, EventArgs e)
        {
            listPelaajaLista.ItemsSource = pelaajalista;
            listPelaajaLista.DisplayMemberPath = "KokoNimi";
        }

        private void btnTalleta_Click(object sender, RoutedEventArgs e)
        {
            if (pelaajalista.Count > 0)
            {
                pelaajalista[editIndex].EtuNimi = txtEtunimi.Text;
                pelaajalista[editIndex].SukuNimi = txtSukunimi.Text;
                if (txtSiirtohinta.Text!="")
                {
                    pelaajalista[editIndex].Siirtohinta = Double.Parse(txtSiirtohinta.Text);
                } else
                {
                    pelaajalista[editIndex].Siirtohinta = 0;
                }
                
                List<string> tmpSeuralist = joukkue.getJoukkueet();
                pelaajalista[editIndex].Seura = tmpSeuralist[CmbSeura.SelectedIndex];

                paivitaLista();
            }
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            if (pelaajalista.Count > 0)
            {
                pelaajalista.RemoveAt(editIndex);
                editIndex = 0;
                paivitaLista();
            }
        }

        private void btnKirjoitaPelaajat_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {

                //System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

                string name = saveFileDialog.FileName;
                //fs.Close();
                using (StreamWriter sw = new StreamWriter(name + ".txt"))
                    for(int i= 0; i < pelaajalista.Count; i ++) {
                        string tmp = pelaajalista[i].EtuNimi + "," + pelaajalista[i].SukuNimi + "," + pelaajalista[i].Siirtohinta + "," + pelaajalista[i].Seura;
                        sw.WriteLine(tmp);
                    }
                //fs.Close();
            }
        }
    }
}

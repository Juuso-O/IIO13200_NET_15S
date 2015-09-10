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

namespace Tehtävä2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numberOfDraws = 1;
        BLLotto lottery = new BLLotto();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < numberOfDraws; i++)
            {
                List<int> tmpList = lottery.draw();
                for (int j = 0; j < tmpList.Count; j++)
                {
                    if (lottery.type == "System.Windows.Controls.ComboBoxItem: Eurojackpot" && j > 4)
                    {
                        txtDraws.Text += "(" + tmpList[j].ToString() + ") ";
                    } else
                    {
                        txtDraws.Text += tmpList[j].ToString() + " ";
                    }
                }
                txtDraws.Text += "\n";
            }
        }

        private void txtNumberOfDraws_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNumberOfDraws.Text != "")
            {
                try
                {
                    numberOfDraws = int.Parse(txtNumberOfDraws.Text);
                } catch(FormatException)
                {
                    MessageBox.Show("Only numbers are allowed here!");
                    txtNumberOfDraws.Focus();
                    txtNumberOfDraws.SelectAll();
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lottery.type = comboBox.SelectedItem.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtDraws.Text = "";
        }
    }
}

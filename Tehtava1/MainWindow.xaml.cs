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

namespace Tehtava1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool changed = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (changed == true) {
                try
                {
                    int windowHeight = int.Parse(txtWindowHeight.Text);
                    int windowWidth = int.Parse(txtWindowWidth.Text);
                    int borderWidth = int.Parse(txtBorderWidth.Text);

                    txtWindowSurface.Text = (windowHeight * windowWidth).ToString() + " m^2";
                    txtBorderRadius.Text = (windowHeight * 2 + windowWidth * 2 + 8 * borderWidth).ToString();
                    txtBorderSurface.Text = (windowHeight * 2 * borderWidth + windowWidth * 2 * borderWidth + borderWidth * borderWidth * 4).ToString();

                    changed = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Numeroita");
                }
            }
          }

        private void txtWindowWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
        }

        private void txtWindowHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
        }

        private void txtBorderWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            changed = true;
        }
    }
}

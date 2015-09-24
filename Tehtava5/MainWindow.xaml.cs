﻿using System;
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

namespace Tehtava5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetDataTable_Click(object sender, RoutedEventArgs e)
        {
            dgData.DataContext = JAMK.IT.DbDemoxOy.GetDataReal("").DefaultView;
        }

        private void btnGetDataView_Click(object sender, RoutedEventArgs e)
        {
            dgData.DataContext = JAMK.IT.DbDemoxOy.GetDataReal(txtBox.Text).DefaultView;
        }

        private void btnGetDataSet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

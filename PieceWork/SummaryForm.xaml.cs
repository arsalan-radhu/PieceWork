/*
 * Name: Arsalan Arif Radhu
 * Student ID: 100813965
 * Date: 4 October 2021
 * Description: Summary form which will display all the summary which was preciously shown on the main form.
 */
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
using System.Windows.Shapes;

namespace PieceWork
{
    /// <summary>
    /// Interaction logic for SummaryForm.xaml
    /// </summary>
    public partial class SummaryForm : Window
    {
        public SummaryForm()
        {
            InitializeComponent();
        }
        
        private void ClickCloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

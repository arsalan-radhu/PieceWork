/*
 * Name: Arsalan Arif Radhu
 * Student ID: 100813965
 * Date: 4 October 2021
 * Modified: 7 October 2021
 * Description: Summary form which will display all the summary which was preciously shown on the main form.
 */
using System;
using System.Linq;
using System.Text;
using System.Windows;


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
            PopulateSummary();
        }
        
        /// <summary>
        /// Closes Summary Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Fill the textboxes of the summary form
        /// </summary>
        private void PopulateSummary()
        {
            //Display the summary values
            textBoxTotalPay.Text = PieceworkWorker.TotalPay.ToString("C");
            textBoxAveragePay.Text = PieceworkWorker.AveragePay.ToString("C");
            textBoxTotalWorkers.Text = PieceworkWorker.TotalWorkers.ToString();
            textBoxTotalMessages.Text = PieceworkWorker.TotalMessages.ToString();
        }

        /// <summary>
        /// Resets the summary form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetSummaryClick(object sender, RoutedEventArgs e)
        {
            PieceworkWorker.ResetSummary();
            //Display the summary values
            PopulateSummary();
        }
    }
}

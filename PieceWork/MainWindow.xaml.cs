// Title: IncInc Payroll (Piecework)
// Last Modified: 25 September 2021
// Written By: Arsalan Arif Radhu
// Description: Made a WPF form IncInc which accepts the worker name and the number of messages sent by them, and then calculates their pay as well as the total pay, total number of worker and the average pay.
using System;
using System.Windows;




namespace PieceWork
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

        /// <summary>
        /// Validates and calculate pay per messages (using a class defined elsewhere) by instantiating the PieceWorker and dis[plays the various values for output using class properties. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            //Attempt to make a new worker
            PieceworkWorker worker = new PieceworkWorker(textBoxWorkerName.Text, textBoxMessagesSent.Text);

            // Display worker's pay
            textBoxSinglePay.Text = worker.Pay.ToString();
            //Display he summary values
            textBoxTotalPay.Text = worker.TotalPay.ToString();
            textBoxAveragePay.Text = worker.AveragePay.ToString();
            textBoxTotalWorkers.Text = worker.TotalWorkers.ToString(); 

            // Disable input related fields
            textBoxWorkerName.IsReadOnly = true;
            textBoxMessagesSent.IsReadOnly = true;
            buttonCalculate.IsEnabled = false;

            //If the worker is not created successfully, show error.
        }

        /// <summary>
        /// Reset the form to its default state with all the text input and output fields cleared.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            // Clear all input fields
            textBoxWorkerName.Clear();
            textBoxMessagesSent.Clear();
            
            //Clear all output fields
            textBoxSinglePay.Clear();
            textBoxTotalWorkers.Clear();
            textBoxTotalPay.Clear();
            textBoxAveragePay.Clear();

            //Renable any controls that may be disabled
            textBoxWorkerName.IsReadOnly = false;
            textBoxMessagesSent.IsReadOnly = false;
            buttonCalculate.IsEnabled = true;

            //Set Focus
            textBoxWorkerName.Focus();

        }
    }
}

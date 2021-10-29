// Title: IncInc Payroll (Piecework)
// Last Modified: 8 October 2021
// Written By: Arsalan Arif Radhu
// Description: Made a WPF form IncInc which accepts the worker name and the number of messages sent by them, and then calculates their pay as well as the total pay, total number of worker and the average pay.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



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
        PieceworkWorker worker;

        /// <summary>
        /// Validates and calculate pay per messages (using a class defined elsewhere) by instantiating the PieceWorker and dis[plays the various values for output using class properties. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CalculateClick(object sender, RoutedEventArgs e)
        {
            //Clear all errors
            ClearAllErrors();
            try
            {
                //Attempt to make a new worker
                PieceworkWorker pieceworkWorker = new PieceworkWorker(textBoxWorkerName.Text, textBoxMessagesSent.Text);

                // Display worker's pay
                textBoxSinglePay.Text = pieceworkWorker.Pay.ToString("C");

                // Disable input related fields
                textBoxWorkerName.IsReadOnly = true;
                textBoxMessagesSent.IsReadOnly = true;
                buttonCalculate.IsEnabled = false;

                //Add to log file
                string message = $"Worker {textBoxWorkerName.Text} has been entered with {textBoxMessagesSent.Text} messages and pay of {textBoxSinglePay.Text}";
                PieceworkWorker.logFunction(message);

            }
            //If the worker is not created successfully, show error.
            catch (ArgumentNullException error)
            {
                // Report Error
                if (error.ParamName == "name")
                { 
                    labelWorkerNameError.Content = error.Message;
                    HighlightError(textBoxWorkerName);
                }

                else if (error.ParamName == "messages")
                {
                    labelMessagesSentError.Content = error.Message;
                    HighlightError(textBoxMessagesSent);
                }

            }
            catch (ArgumentOutOfRangeException error)
            {
                // Report Error
                if (error.ParamName == "messages")
                {
                    labelMessagesSentError.Content = error.Message;
                    HighlightError(textBoxMessagesSent);
                }

            }
            catch (ArgumentException error)
            {
                // Report Error
                if (error.ParamName == "name")
                {
                    labelWorkerNameError.Content = error.Message;
                    HighlightError(textBoxWorkerName);
                }

                else if (error.ParamName == "messages")
                {
                    labelMessagesSentError.Content = error.Message;
                    HighlightError(textBoxMessagesSent);
                }

            }

            catch (Exception error)
            {
                MessageBox.Show("An unexpected error has occurred! Contact your IT department with the following information for support:\n"+
                                "\nSource"+error.Source+
                                "\nMessage"+error.Message+
                                "\nType"+error.GetType()+
                                "\nStack Trace" + error.StackTrace);
            }
           
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

            //Reenable any controls that may be disabled
            textBoxWorkerName.IsReadOnly = false;
            textBoxMessagesSent.IsReadOnly = false;
            buttonCalculate.IsEnabled = true;


            //Clear all errors
            ClearAllErrors();

        }

        /// <summary>
        ///Exits the application 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Highlight a textbox by putting colors on it and selecting it.
        /// </summary>
        /// <param name="textBoxInError"></param>
        private void HighlightError(TextBox textBoxInError)
        {
            textBoxInError.Background = Brushes.Red;
            textBoxInError.BorderBrush = Brushes.DarkRed;
            textBoxInError.SelectAll();
            textBoxInError.Focus();
        }

        /// <summary>
        /// Clear the highlight from a textbox, resetting it to near-default colors.
        /// </summary>
        /// <param name="textBoxToClear"></param>
        private void ClearError(TextBox textBoxToClear)
        {
            textBoxToClear.Background = Brushes.White;
            textBoxToClear.BorderBrush = Brushes.Black;
        }

        /// <summary>
        /// Clear all error messages
        /// </summary>
        private void ClearAllErrors()
        {
            ClearError(textBoxWorkerName);
            ClearError(textBoxMessagesSent);
            labelWorkerNameError.Content = String.Empty;
            labelMessagesSentError.Content = String.Empty;
        }

        /// <summary>
        /// When the tab controls selection is changed, respond to it by populating the target tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabChanged(object sender, SelectionChangedEventArgs e)
        {
            //When we access the entry form,set focus
            if (tabControlInterface.SelectedItem == tabPayrollEntry)
            {
                buttonClear.Focus();
            }
            // When we access the summary form, populate summary values from the database
            else if (tabControlInterface.SelectedItem == tabSummary)
            {
                PopulateSummary();
            }
            // When we access the Employee list form, populate it from the database. 
            else if (tabControlInterface.SelectedItem == tabEmployeeList)
            {
                //This directly accesses the DataAccess layer; it should probably through the class
                dataGridEmployees.ItemsSource = PieceworkWorker.AllWorkers.DefaultView;
            }
        }
    }
}

// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: 8 October 2021
//    Written By: Arsalan Arif Radhu
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.

// This is currently incomplete; note the four comment blocks
// below that begin with "TO DO"


using System;
using System.IO;
using Microsoft.Win32;



namespace PieceWork // Ensure this namespace matches your own
{
    class PieceworkWorker
    {

        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private int employeeMessages;
        private decimal employeePay;
        

        // Shared class variables
        private static int overallNumberOfEmployees;
        private static int overallMessages;
        private static decimal overallPayroll;

        //CONSTANTS
        private const int zero = 0;
        private const int firstThreshold = 1250;
        private const int secondThreshold = 2500;
        private const int thirdThreshold = 3750;
        private const int lastThreshold = 5000;
        private const int maxMessages = 15000;

        private const decimal firstThresholdPay = 0.02M;
        private const decimal secondThresholdPay = 0.024M;
        private const decimal thirdThresholdPay = 0.028M;
        private const decimal fourthThresholdPay = 0.034M;
        private const decimal lastThresholdPay = 0.04M;

        // Constants for exception parameter name
        public const string NameParameters = "name";
        public const string MessagesParameters = "messages";
        

        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public PieceworkWorker()
        {
            
        }


        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public PieceworkWorker(string nameValue, string messagesValue)
        {
            // Validate and set the worker's name
            this.Name = nameValue;
            // Validate Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Calculcate the worker's pay and update all summary values
            FindPay();
            
        }

        

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the findPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
        private void FindPay()
        {

            if (employeeMessages < firstThreshold && employeeMessages > zero)
            { 
                employeePay = (decimal) (employeeMessages * firstThresholdPay);
            }
            else if (employeeMessages < secondThreshold && employeeMessages >= firstThreshold) 
            { 
                employeePay = (decimal)(employeeMessages * secondThresholdPay);
            }
            else if (employeeMessages < thirdThreshold && employeeMessages >= secondThreshold)
            { 
                employeePay = (decimal)(employeeMessages * thirdThresholdPay);
            }
            else if (employeeMessages < lastThreshold && employeeMessages >= thirdThreshold)
            { 
                employeePay = (decimal)(employeeMessages * fourthThresholdPay);
            }
            else if(employeeMessages >= lastThreshold && employeeMessages <= maxMessages)
            { 
                employeePay = (decimal)(employeeMessages * lastThresholdPay);
            }
            else
            {
                throw new ArgumentOutOfRangeException(MessagesParameters,
                    "Enter less than 15000!");
            }

            // Update all summary variables
            overallNumberOfEmployees++;
            overallMessages += employeeMessages;
            overallPayroll += employeePay;
            
       
        }

        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                return employeeName.ToString();
            }
            set
            {
                // Add validation for the worker's name based on the requirement.
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameParameters, "Name cannot be blank.");
                }
                else
                {
                    employeeName = value;
                }
               
            }
        }

        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                return employeeMessages.ToString();
            }
            set
            {

                // Check if number of messages entered in whole number or not
                if (int.TryParse(value, out employeeMessages))
                {
                    // If number entered is whole number, check if it is in a valid range
                    if (employeeMessages <= zero || employeeMessages.ToString() =="")
                    {
                        // If not in valid range, report error
                        throw new ArgumentOutOfRangeException(MessagesParameters,
                            "Messages should be greater than ZERO!");

                    }
                }
                else
                {
                    //If not a numeric value, report an error
                    ArgumentException error =
                        new ArgumentException("Enter a WHOLE number!",MessagesParameters);
                    throw error;
                }


            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay
        {
            get
            {
                return employeePay;
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {
                return overallPayroll;
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers
        {
            get
            {
                return overallNumberOfEmployees;
            }
        }

        /// <summary>
        /// Gets the overall number of messages sent
        /// </summary>
        /// <returns>the overall number of messages sent</returns>
        public static int TotalMessages
        {
            get
            {
                return overallMessages;
            }
        }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {
            get
            {
               
                if (TotalWorkers == 0 || TotalPay == 0)
                {
                    return zero;
                }
                else
                {
                    return Decimal.Round(TotalPay / TotalWorkers,2);
                }
                
            }
        }

        /// <summary>
        /// Rests the summary values to zero
        /// </summary>
        public static void ResetSummary()
        {
            overallMessages = 0;
            overallNumberOfEmployees = 0;
            overallPayroll = 0;
        }

        /// <summary>
        /// Save the successful entries into a log file.
        /// </summary>
        /// <param name="message"></param>
        public static void logFunction(string message)
        {
            string logPath = "../../../log.txt";
            StreamWriter log = new StreamWriter(logPath, true);
            log.WriteLine($"{DateTime.Now}: {message}");
            log.Close();
        }

        #endregion

    }

  
}

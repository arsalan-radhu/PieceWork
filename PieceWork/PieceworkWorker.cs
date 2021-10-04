// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: 25 September 2021
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PieceWork // Ensure this namespace matches your own
{
    public class PieceworkWorker
    {

        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private int employeeMessages;
        private decimal employeePay;

        private bool isValid = true;

        // Shared class variables
        private static int overallNumberOfEmployees;
        private static int overallMessages;
        private static decimal overallPayroll;

        //CONSTANTS
        private const int ZERO = 0;
        private const int firstThreshold = 1250;
        private const int secondThreshold = 2500;
        private const int thirdThreshold = 3750;
        private const int lastThreshold = 5000;

        private const decimal firstThresholdPay = 0.02M;
        private const decimal secondThresholdPay = 0.024M;
        private const decimal thirdThresholdPay = 0.028M;
        private const decimal fourthThresholdPay = 0.034M;
        private const decimal lastThresholdPay = 0.04M;

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
            // TO DO
            // Fill in this entire method by following the instructions provided
            // in the NETD 3202 Lab 1 handout
            // It is suggested that you use the requirements as a checklist in
            // order to ensure you don't miss any requirements.

            // Check if worker is considered valid.
            if (isValid)
            {
                // If the worker is valid, check which range they are in 
                if (employeeMessages < firstThreshold && employeeMessages > ZERO)
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
                else if(employeeMessages >= lastThreshold)
                {
                    employeePay = (decimal)(employeeMessages * lastThresholdPay);
                }

                // Update all summary variables
                overallNumberOfEmployees++;
                overallMessages += employeeMessages;
                overallPayroll += employeePay;
            }
            else
            {
                MessageBox.Show("INVALID ENTRY!!");
            }
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
                // TO DO
                // Add validation for the worker's name based on the requirements
                // document
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Please Enter a name!", "Invalid Input ");
                    isValid = false;
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
                // TO DO
                // Add validation for the number of messages based on the
                // requirements document

                // Check if number of messages entered in whole number or not
                if (int.TryParse(value, out employeeMessages))
                {
                    // If number entered is whole number, check if it is in a valid range
                    if (employeeMessages < ZERO)
                    {
                        // If not in valid range, report error
                        isValid = false;
                        MessageBox.Show("The number of messages should be greater than ZERO!","Invalid Entry!");
                    }
                }
                else
                {
                    //If not a numeric value, report an error
                    isValid = false;
                    MessageBox.Show("The number of message entered should be a WHOLE number!" , "Invalid Entry!");
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
        public decimal TotalPay
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
        public int TotalWorkers
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
        public int TotalMessages
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
        public  decimal AveragePay
        {
            get
            {
                // TO DO
                // Write the logic that will return the average pay among all workers. Test this carefully!
                if (TotalWorkers == 0 || TotalPay == 0)
                {
                    return ZERO;
                }
                else
                {
                    return TotalPay / TotalWorkers;
                }
                
            }
        }

        #endregion

    }
}

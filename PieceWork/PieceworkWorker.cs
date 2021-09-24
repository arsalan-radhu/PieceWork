//// PieceworkWorker.cs
////         Title: IncInc Payroll (Piecework)
//// Last Modified: 
////    Written By: 
//// Adapted from PieceworkWorker by Kyle Chapman, September 2019
//// 
//// This is a class representing individual worker objects. Each stores
//// their own name and number of messages and the class methods allow for
//// calculation of the worker's pay and for updating of shared summary
//// values. Name and messages are received as strings.
//// This is being used as part of a piecework payroll application.

//// This is currently incomplete; note the four comment blocks
//// below that begin with "TO DO"

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PieceWork // Ensure this namespace matches your own
//{
//    class PieceworkWorker
//    {

//        #region "Variable declarations"

//        // Instance variables
//        private string employeeName;
//        private int employeeMessages;
//        private decimal employeePay;

//        private bool isValid = true;

//        // Shared class variables
//        private static int overallNumberOfEmployees;
//        private static int overallMessages;
//        private static decimal overallPayroll;

//        #endregion

//        #region "Constructors"

//        /// <summary>
//        /// PieceworkWorker constructor: accepts a worker's name and number of
//        /// messages, sets and calculates values as appropriate.
//        /// </summary>
//        /// <param name="nameValue">the worker's name</param>
//        /// <param name="messageValue">a worker's number of messages sent</param>
//        public PieceworkWorker(string nameValue, string messagesValue)
//        {
//            // Validate and set the worker's name
//            this.Name = nameValue;
//            // Validate Validate and set the worker's number of messages
//            this.Messages = messagesValue;
//            // Calculcate the worker's pay and update all summary values
//            findPay();
//        }

//        /// <summary>
//        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
//        /// </summary>
//        public PieceworkWorker()
//        {

//        }

//        #endregion

//        #region "Class methods"

//        /// <summary>
//        /// Currently called in the constructor, the findPay() method is
//        /// used to calculate a worker's pay using threshold values to
//        /// change how much a worker is paid per message. This also updates
//        /// all summary values.
//        /// </summary>
//        private void findPay()
//        {
//            // TO DO
//            // Fill in this entire method by following the instructions provided
//            // in the NETD 3202 Lab 1 handout
//            // It is suggested that you use the requirements as a checklist in
//            // order to ensure you don't miss any requirements.

//        }

//        #endregion

//        #region "Property Procedures"

//        /// <summary>
//        /// Gets and sets a worker's name
//        /// </summary>
//        /// <returns>an employee's name</returns>
//        public string Name
//        {
//            get
//            {
//                return employeeName;
//            }
//            set
//            {
//                // TO DO
//                // Add validation for the worker's name based on the requirements
//                // document

//                employeeName = value;
//            }
//        }

//        /// <summary>
//        /// Gets and sets the number of messages sent by a worker
//        /// </summary>
//        /// <returns>an employee's number of messages</returns>
//        public string Messages
//        {
//            get
//            {
//                return employeeMessages.ToString();
//            }
//            set
//            {
//                // TO DO
//                // Add validation for the number of messages based on the
//                // requirements document

//                employeeMessages = Convert.ToInteger(value); // This line is dangerous and should probably never appear in your code. Can you explain why? Post about it on the Q&A board and I'll give you a stock.


//            }
//        }

//        /// <summary>
//        /// Gets the worker's pay
//        /// </summary>
//        /// <returns>a worker's pay</returns>
//        public decimal Pay
//        {
//            get
//            {
//                return employeePay;
//            }
//        }

//        /// <summary>
//        /// Gets the overall total pay among all workers
//        /// </summary>
//        /// <returns>the overall total pay among all workers</returns>
//        public static decimal TotalPay
//        {
//            get
//            {
//                return overallPayroll;
//            }
//        }

//        /// <summary>
//        /// Gets the overall number of workers
//        /// </summary>
//        /// <returns>the overall number of workers</returns>
//        public static int TotalWorkers
//        {
//            get
//            {
//                return overallNumberOfEmployees;
//            }
//        }

//        /// <summary>
//        /// Gets the overall number of messages sent
//        /// </summary>
//        /// <returns>the overall number of messages sent</returns>
//        public static int TotalMessages()
//        {
//            get
//            {
//                return overallMessages;
//            }
//        }

//        /// <summary>
//        /// Calculates and returns an average pay among all workers
//        /// </summary>
//        /// <returns>the average pay among all workers</returns>
//        public static decimal AveragePay
//        {
//            get
//            {
//                // TO DO
//                // Write the logic that will return the average pay among all workers. Test this carefully!
//                return;
//            }
//        }

//        #endregion

//    }
//}

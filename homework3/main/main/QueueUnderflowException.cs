using System;

namespace hw3Ex
{
    /// <summary>
    /// This is a custom unchecked exception to represent situations whee
    /// an illegal operation was performaed on an empty queue.
    /// translated from a java file.
    /// </summary>
	class QueueUnderflowException : Exception
    {
        public QueueUnderflowException() : base() { }



        /// <summary>
        /// This prints the exception message
        /// </summary>
        /// <param name="message"></param>
        public QueueUnderflowException(string message)
            :base(message)
        {
        }
    }
}

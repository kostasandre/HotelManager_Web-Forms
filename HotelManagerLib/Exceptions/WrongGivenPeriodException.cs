// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrongGivenPeriodException.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The wrong given period exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Exceptions
{
    #region

    using System;
    using System.Runtime.Serialization;

    #endregion

    /// <summary>
    /// The wrong given period exception.
    /// </summary>
    public class WrongGivenPeriodException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrongGivenPeriodException"/> class.
        /// </summary>
        public WrongGivenPeriodException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongGivenPeriodException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public WrongGivenPeriodException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongGivenPeriodException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public WrongGivenPeriodException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongGivenPeriodException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected WrongGivenPeriodException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
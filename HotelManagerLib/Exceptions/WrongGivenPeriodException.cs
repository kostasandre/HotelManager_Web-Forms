using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLib.Exceptions
{
    using System.Runtime.Serialization;

    public class WrongGivenPeriodException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrongGivenPeriodException"/> class.
        /// </summary>
        public WrongGivenPeriodException()
            : base()
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
        public WrongGivenPeriodException(string message , Exception innerException)
            : base(message , innerException)
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
        protected WrongGivenPeriodException(SerializationInfo info , StreamingContext context)
            : base(info , context)
        {
        }
    }
}

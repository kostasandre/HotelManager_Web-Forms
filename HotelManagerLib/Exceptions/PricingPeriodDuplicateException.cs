using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLib.Exceptions
{
    using System.Runtime.Serialization;

    using HotelManagerLib.Models.Persistant;

    public class PricingPeriodDuplicateException : Exception
    {
        public List<PricingList> DuplicatePricingListEntries { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PricingPeriodDuplicateException"/> class.
        /// </summary>
        public PricingPeriodDuplicateException(List<PricingList> pricingList )
            : base()
        {
            this.DuplicatePricingListEntries = pricingList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PricingPeriodDuplicateException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public PricingPeriodDuplicateException(string message, List<PricingList> pricingList)
            : base(message)
        {
            this.DuplicatePricingListEntries = pricingList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PricingPeriodDuplicateException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public PricingPeriodDuplicateException(string message , Exception innerException, List<PricingList> pricingList)
            : base(message , innerException)
        {
            this.DuplicatePricingListEntries = pricingList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PricingPeriodDuplicateException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected PricingPeriodDuplicateException(SerializationInfo info , StreamingContext context, List<PricingList> pricingList)
            : base(info , context)
        {
            this.DuplicatePricingListEntries = pricingList;
        }
    }
}

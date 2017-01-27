// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingPeriodDuplicateException.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing period duplicate exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Exceptions
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The pricing period duplicate exception.
    /// </summary>
    public class PricingPeriodDuplicateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PricingPeriodDuplicateException"/> class.
        /// </summary>
        /// <param name="pricingList">
        /// The pricing List.
        /// </param>
        public PricingPeriodDuplicateException(List<PricingList> pricingList)
        {
            this.DuplicatePricingListEntries = pricingList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PricingPeriodDuplicateException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="pricingList">
        /// The pricing List.
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
        /// <param name="pricingList">
        /// The pricing List.
        /// </param>
        public PricingPeriodDuplicateException(string message, Exception innerException, List<PricingList> pricingList)
            : base(message, innerException)
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
        /// <param name="pricingList">
        /// The pricing List.
        /// </param>
        protected PricingPeriodDuplicateException(
            SerializationInfo info,
            StreamingContext context,
            List<PricingList> pricingList)
            : base(info, context)
        {
            this.DuplicatePricingListEntries = pricingList;
        }

        /// <summary>
        /// Gets or sets the duplicate pricing list entries.
        /// </summary>
        public List<PricingList> DuplicatePricingListEntries { get; set; }
    }
}
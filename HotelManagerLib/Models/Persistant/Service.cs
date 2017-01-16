// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service.cs" company="">
//   
// </copyright>
// <summary>
//   The services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models.Persistant
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using HotelManagerLib.Models.Persistant.Interfaces;

    #endregion

    /// <summary>
    /// The services.
    /// </summary>
    public class Service : IBillableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service()
        {
            this.Hotels = new List<Hotel>();
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.UserName;
        }

        /// <summary>
        /// Gets or sets the billing service.
        /// </summary>
        public BillingService BillingService { get; set; }

        /// <summary>
        /// Gets or sets the billing service id.
        /// </summary>
        [Browsable(false)]
        public int? BillingServiceId { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the deleted.
        /// </summary>
        public DateTime? Deleted { get; set; }

        /// <summary>
        /// Gets or sets the deleted by.
        /// </summary>
        public string DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the hotels.
        /// </summary>
        public virtual List<Hotel> Hotels { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service.cs" company="Data Communication">
//   Hotel Manager
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
    using System.ComponentModel.DataAnnotations.Schema;

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
            this.BillingServices = new List<BillingService>();
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.UserName;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the billing services.
        /// </summary>
        public IList<BillingService> BillingServices { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the hotel.
        /// </summary>
        public virtual Hotel Hotel { get; set; }
        
        /// <summary>
        /// Gets or sets the hotel id.
        /// </summary>
        [ForeignKey("Hotel")]
        [Browsable(false)]
        public int HotelId { get; set; }

        /// <summary>
        /// The hotel name.
        /// </summary>
        public string HotelName => this.Hotel.Name;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the deleted.
        /// </summary>
        public DateTime? Deleted { get; set; }

        /// <summary>
        /// Gets or sets the deleted by.
        /// </summary>
        public string DeletedBy { get; set; }
    }
}
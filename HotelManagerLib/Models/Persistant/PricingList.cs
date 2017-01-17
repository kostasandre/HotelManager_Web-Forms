// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingList.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models.Persistant
{
    #region

    using System;
    using System.ComponentModel;

    using HotelManagerLib.Models.Persistant.Interfaces;

    #endregion

    /// <summary>
    /// The pricing list.
    /// </summary>
    public class PricingList : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PricingList"/> class.
        /// </summary>
        public PricingList()
        {
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.UserName;
        }

        /// <summary>
        /// Gets or sets the billable entity.
        /// </summary>
        public IBillableEntity BillableEntity { get; set; }

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
        /// Gets or sets the id.
        /// </summary>
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the valid from.
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Gets or sets the valid to.
        /// </summary>
        public DateTime ValidTo { get; set; }

        /// <summary>
        /// Gets or sets the vat price.
        /// </summary>
        public double VatPrc { get; set; }
    }
}
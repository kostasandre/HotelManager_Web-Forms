// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Booking.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The booking.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models.Persistant
{
    #region

    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant.Interfaces;

    #endregion

    /// <summary>
    /// The booking.
    /// </summary>
    public class Booking : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        public Booking()
        {
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.UserName;
        }

        /// <summary>
        /// Gets or sets the agreed price.
        /// </summary>
        public double AgreedPrice { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public string Comments { get; set; }
        
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        [Browsable(false)]
        public int CustomerId { get; set; }
        
        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the room.
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Gets or sets the room id.
        /// </summary>
        [ForeignKey("Room")]
        [Browsable(false)]
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the system price.
        /// </summary>
        public double SystemPrice { get; set; }

        /// <summary>
        /// Gets or sets the to.
        /// </summary>
        public DateTime To { get; set; }
        
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
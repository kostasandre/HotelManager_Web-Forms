// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hotel.cs" company="">
//   
// </copyright>
// <summary>
//   The hotel.
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
    /// The hotel.
    /// </summary>
    public class Hotel : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        public Hotel()
        {
            this.Rooms = new List<Room>();
            this.Services = new List<Service>();
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.UserName;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

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
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public virtual Picture Picture { get; set; }

        /// <summary>
        /// Gets or sets the picture id.
        /// </summary>
        [ForeignKey("Picture")]
        [Browsable(false)]
        public int? PictureId { get; set; }

        /// <summary>
        /// Gets or sets the rooms.
        /// </summary>
        public virtual List<Room> Rooms { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        public virtual List<Service> Services { get; set; }

        /// <summary>
        /// Gets or sets the tax id.
        /// </summary>
        public string TaxId { get; set; }

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
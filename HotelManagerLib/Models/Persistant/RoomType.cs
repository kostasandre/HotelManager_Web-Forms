// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomType.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models.Persistant
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant.Interfaces;

    #endregion

    /// <summary>
    /// The room type.
    /// </summary>
    public class RoomType : IBillableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomType"/> class.
        /// </summary>
        public RoomType()
        {
            this.Rooms = new List<Room>();
            
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.UserName;
        }

        /// <summary>
        /// Gets or sets the bed type.
        /// </summary>
        public BedType BedType { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the rooms.
        /// </summary>
        public virtual List<Room> Rooms { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether sauna.
        /// </summary>
        public bool Sauna { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Television.
        /// </summary>
        public bool Tv { get; set; }
        
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public View View { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether wi fi.
        /// </summary>
        public bool WiFi { get; set; }

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
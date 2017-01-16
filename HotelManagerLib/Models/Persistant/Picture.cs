// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Picture.cs" company="">
//   
// </copyright>
// <summary>
//   The picture.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models.Persistant
{
    #region

    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    using HotelManagerLib.Models.Persistant.Interfaces;

    #endregion

    /// <summary>
    /// The picture.
    /// </summary>
    public class Picture : IEntity, IEntityAudit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Picture"/> class.
        /// </summary>
        public Picture()
        {
            this.Created = DateTime.Now;
            this.CreatedBy = Environment.UserName;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public byte[] Content { get; set; }

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
        /// Gets or sets the updated.
        /// </summary>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
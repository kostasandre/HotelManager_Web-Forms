// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntityAudit.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The EntityAudit interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models.Persistant.Interfaces
{
    using System;

    /// <summary>
    /// The EntityAudit interface.
    /// </summary>
    public interface IEntityAudit
    {
        /// <summary>
        /// Gets or sets the date and time when the document is created.
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets when a document is updated.
        /// </summary>
        DateTime? Updated { get; set; }

        /// <summary>
        /// Gets or sets when a document is deleted.
        /// </summary>
        DateTime? Deleted { get; set; }

        /// <summary>
        /// Gets or sets from who a document is created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets from who a document is updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets from who a document is deleted by.
        /// </summary>
        string DeletedBy { get; set; }
    }
}
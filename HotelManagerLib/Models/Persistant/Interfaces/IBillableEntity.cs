// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBillableEntity.cs" company="">
//   
// </copyright>
// <summary>
//   The BillableEntity interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models.Persistant.Interfaces
{
    /// <summary>
    /// The BillableEntity interface.
    /// </summary>
    public interface IBillableEntity : IEntity, IEntityAudit
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        string Code { get; set; }
    }
}
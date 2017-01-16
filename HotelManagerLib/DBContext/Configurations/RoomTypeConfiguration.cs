// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomTypeConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The room type configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.DBContext.Configurations
{
    #region

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The room type configuration.
    /// </summary>
    public class RoomTypeConfiguration : EntityTypeConfiguration<RoomType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomTypeConfiguration"/> class.
        /// </summary>
        public RoomTypeConfiguration()
        {
            this.ToTable("RoomType");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasMany(x => x.Rooms).WithRequired(x => x.RoomType).HasForeignKey(x => x.RoomTypeId);

            // Required Entities
            this.Property(x => x.Code).IsRequired().HasMaxLength(150);
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomConfiguration.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room configuration.
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
    /// The room configuration.
    /// </summary>
    public class RoomConfiguration : EntityTypeConfiguration<Room>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomConfiguration"/> class.
        /// </summary>
        public RoomConfiguration()
        {
            this.ToTable("Room");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasMany(x => x.Pictures).WithMany();
            this.HasRequired(x => x.Hotel).WithMany(x => x.Rooms).HasForeignKey(x => x.HotelId).WillCascadeOnDelete(false);
            this.HasRequired(x => x.RoomType).WithMany(x => x.Rooms).HasForeignKey(x => x.RoomTypeId);
            
            // Required Entities
            this.Property(x => x.Code).IsRequired().HasMaxLength(150);
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomTypeConfiguration.cs" company="Data Communication">
//   Hotel Manager
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

    using Models.Persistant;

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

            // Required Entities
            this.Property(x => x.Code).IsRequired().HasMaxLength(150);
        }
    }
}
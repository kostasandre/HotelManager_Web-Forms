// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The hotel configuration.
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
    /// The hotel configuration.
    /// </summary>
    public class HotelConfiguration : EntityTypeConfiguration<Hotel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotelConfiguration"/> class.
        /// </summary>
        public HotelConfiguration()
        {
            this.ToTable("Hotel");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasMany(x => x.Rooms).WithRequired(x => x.Hotel).HasForeignKey(x => x.HotelId);
            this.HasOptional(x => x.Picture);
            this.HasOptional(x => x.Services).WithMany().WillCascadeOnDelete(false);

            // Required Entities
            this.Property(x => x.Name).IsRequired().HasMaxLength(150);
            this.Property(x => x.Manager).IsRequired().HasMaxLength(150);
            this.Property(x => x.TaxId).IsRequired().HasMaxLength(11);
            this.Property(x => x.Address).IsRequired();
            this.Property(x => x.Phone).IsRequired();
        }
    }
}
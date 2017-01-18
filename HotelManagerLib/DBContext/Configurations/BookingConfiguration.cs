// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The booking configuration.
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
    /// The booking configuration.
    /// </summary>
    public class BookingConfiguration : EntityTypeConfiguration<Booking>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingConfiguration"/> class.
        /// </summary>
        public BookingConfiguration()
        {
            this.ToTable("Booking");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasRequired(x => x.Room).WithMany();

            // Required Entities
            this.Property(x => x.SystemPrice).IsRequired();
            this.Property(x => x.AgreedPrice).IsRequired();
            this.Property(x => x.CustomerId).IsRequired();
            this.Property(x => x.Status).IsRequired();
            this.Property(x => x.To).IsRequired();
            this.Property(x => x.From).IsRequired();
        }
    }
}
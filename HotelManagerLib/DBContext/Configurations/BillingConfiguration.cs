// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The billing configuration.
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
    /// The billing configuration.
    /// </summary>
    public class BillingConfiguration : EntityTypeConfiguration<Billing>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingConfiguration"/> class.
        /// </summary>
        public BillingConfiguration()
        {
            this.ToTable("Billing");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasRequired(x => x.Booking);
            this.HasMany(x => x.BillingServices).WithRequired(x => x.Billing).HasForeignKey(x => x.BillingId);

            // Required Entities
            this.Property(x => x.Paid).IsRequired();
            this.Property(x => x.PriceForRoom).IsRequired();
            this.Property(x => x.PriceForServices).IsRequired();
            this.Property(x => x.TotalPrice).IsRequired();
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingServiceConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The billing service configuration.
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
    /// The billing service configuration.
    /// </summary>
    public class BillingServiceConfiguration : EntityTypeConfiguration<BillingService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingServiceConfiguration"/> class.
        /// </summary>
        public BillingServiceConfiguration()
        {
            this.ToTable("BillingService");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasMany(x => x.Services).WithRequired(x => x.BillingService).HasForeignKey(x => x.BillingServiceId);

            // Required Entities
            this.Property(x => x.Price).IsRequired();
            this.Property(x => x.Quantity).IsRequired();
        }
    }
}
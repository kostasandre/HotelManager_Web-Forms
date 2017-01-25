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

            // Required Entities
            this.Property(x => x.Price).IsRequired();
            this.Property(x => x.Quantity).IsRequired();

            // Foreign Keys
            this.HasRequired(x => x.Service).WithMany(x => x.BillingServices).HasForeignKey(x => x.ServiceId);
            this.HasRequired(x => x.Billing).WithMany(x => x.BillingServices).HasForeignKey(x => x.BillingId).WillCascadeOnDelete(false);
        }
    }
}
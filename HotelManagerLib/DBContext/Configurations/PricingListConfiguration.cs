// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingListConfiguration.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing list configuration.
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
    /// The pricing list configuration.
    /// </summary>
    public class PricingListConfiguration : EntityTypeConfiguration<PricingList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PricingListConfiguration"/> class.
        /// </summary>
        public PricingListConfiguration()
        {
            this.ToTable("PricingList");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Required Entities
            this.Property(x => x.Price).IsRequired();
            this.Property(x => x.VatPrc).IsRequired();
            this.Property(x => x.BillableEntityId).IsRequired();
            this.Property(x => x.TypeOfBillableEntity).IsRequired();
        }
    }
}
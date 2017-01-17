// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicesConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The services configuration.
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
    /// The services configuration.
    /// </summary>
    public class ServicesConfiguration : EntityTypeConfiguration<Service>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesConfiguration"/> class.
        /// </summary>
        public ServicesConfiguration()
        {
            this.ToTable("Service");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Foreign Keys
            this.HasOptional(x => x.Hotels).WithMany().WillCascadeOnDelete(false);
            this.HasMany(x => x.BillingServices).WithRequired(x => x.Service).HasForeignKey(x => x.ServiceId);

            // Required Entities
            this.Property(x => x.Code).IsRequired().HasMaxLength(150);
        }
    }
}
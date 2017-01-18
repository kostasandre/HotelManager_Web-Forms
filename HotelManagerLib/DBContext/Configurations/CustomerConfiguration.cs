// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The customer configuration.
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
    /// The customer configuration.
    /// </summary>
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerConfiguration"/> class.
        /// </summary>
        public CustomerConfiguration()
        {
            this.ToTable("Customer");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Required Entities
            this.Property(x => x.Name).IsRequired().HasMaxLength(150);
            this.Property(x => x.Surname).IsRequired().HasMaxLength(150);
        }
    }
}
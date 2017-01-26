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
            this.HasRequired(x => x.Hotel).WithMany(x => x.Services).HasForeignKey(x => x.HotelId).WillCascadeOnDelete(false);

            // Required Entities
            this.Property(x => x.Code).IsRequired().HasMaxLength(150);
        }
    }
}
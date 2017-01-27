// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureConfiguration.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The picture configuration.
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
    /// The picture configuration.
    /// </summary>
    public class PictureConfiguration : EntityTypeConfiguration<Picture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PictureConfiguration"/> class.
        /// </summary>
        public PictureConfiguration()
        {
            this.ToTable("Picture");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Code).IsRequired().HasMaxLength(150);
            this.Property(x => x.Content).IsRequired();
        }
    }
}
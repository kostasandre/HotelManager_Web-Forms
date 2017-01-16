using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLib.DBContext.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using HotelManagerLib.Models.Persistant;

    class PricingListConfiguration : EntityTypeConfiguration<PricingList>
    {
        public PricingListConfiguration()
        {
            this.ToTable("PricingList");

            // Primary Keys
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Required Entities
            this.Property(x => x.Price).IsRequired();
            this.Property(x => x.VatPrc).IsRequired();
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBaseContext.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The data base context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.DBContext
{
    #region

    using System.Data.Entity;

    using HotelManagerLib.DBContext.Configurations;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The data base context.
    /// </summary>
    public class DataBaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseContext"/> class.
        /// </summary>
        public DataBaseContext()
            : base("ConnectionString")
        {
        }

        /// <summary>
        /// Gets or sets the billings.
        /// </summary>
        public DbSet<Billing> Billings { get; set; }

        /// <summary>
        /// Gets or sets the billing service configurations.
        /// </summary>
        public DbSet<BillingService> BillingServices { get; set; }

        /// <summary>
        /// Gets or sets the bookings.
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the Hotel.
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }

        /// <summary>
        /// Gets or sets the Picture.
        /// </summary>
        public DbSet<Picture> Pictures { get; set; }

        /// <summary>
        /// Gets or sets the pricing list.
        /// </summary>
        public DbSet<PricingList> PricingList { get; set; }

        /// <summary>
        /// Gets or sets the Room.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// Gets or sets the RoomType.
        /// </summary>
        public DbSet<RoomType> RoomTypes { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new HotelConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new RoomTypeConfiguration());
            modelBuilder.Configurations.Add(new PictureConfiguration());
            modelBuilder.Configurations.Add(new ServicesConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new BookingConfiguration());
            modelBuilder.Configurations.Add(new BillingConfiguration());
            modelBuilder.Configurations.Add(new BillingServiceConfiguration());
        }
    }
}
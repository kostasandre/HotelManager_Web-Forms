// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBaseContext.cs" company="">
//   
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
        /// Gets or sets the Hotel.
        /// </summary>
        public DbSet<Hotel> Hotel { get; set; }

        /// <summary>
        /// Gets or sets the Picture.
        /// </summary>
        public DbSet<Picture> Picture { get; set; }

        /// <summary>
        /// Gets or sets the Room.
        /// </summary>
        public DbSet<Room> Room { get; set; }

        /// <summary>
        /// Gets or sets the RoomType.
        /// </summary>
        public DbSet<RoomType> RoomType { get; set; }

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
        }
    }
}
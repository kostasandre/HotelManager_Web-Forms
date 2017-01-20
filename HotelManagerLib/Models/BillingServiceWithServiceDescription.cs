// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingServiceWithServiceDescription.cs" company="">
//   
// </copyright>
// <summary>
//   The billing service with service description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models
{
    /// <summary>
    /// The billing service with service description.
    /// </summary>
    public class BillingServiceWithServiceDescription
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double PricePerUnit { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        public double TotalPrice { get; set; }
        
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingCalendar.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The booking calendar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Models
{
    /// <summary>
    /// The booking calendar.
    /// </summary>
    public class BookingCalendar
    {
        /// <summary>
        /// Gets or sets the day 1.
        /// </summary>
        public AvailableStatus Day1 { get; set; }

        /// <summary>
        /// Gets or sets the day 10.
        /// </summary>
        public AvailableStatus Day10 { get; set; }

        /// <summary>
        /// Gets or sets the day 11.
        /// </summary>
        public AvailableStatus Day11 { get; set; }

        /// <summary>
        /// Gets or sets the day 12.
        /// </summary>
        public AvailableStatus Day12 { get; set; }

        /// <summary>
        /// Gets or sets the day 13.
        /// </summary>
        public AvailableStatus Day13 { get; set; }

        /// <summary>
        /// Gets or sets the day 14.
        /// </summary>
        public AvailableStatus Day14 { get; set; }

        /// <summary>
        /// Gets or sets the day 15.
        /// </summary>
        public AvailableStatus Day15 { get; set; }

        /// <summary>
        /// Gets or sets the day 16.
        /// </summary>
        public AvailableStatus Day16 { get; set; }

        /// <summary>
        /// Gets or sets the day 17.
        /// </summary>
        public AvailableStatus Day17 { get; set; }

        /// <summary>
        /// Gets or sets the day 18.
        /// </summary>
        public AvailableStatus Day18 { get; set; }

        /// <summary>
        /// Gets or sets the day 19.
        /// </summary>
        public AvailableStatus Day19 { get; set; }

        /// <summary>
        /// Gets or sets the day 2.
        /// </summary>
        public AvailableStatus Day2 { get; set; }

        /// <summary>
        /// Gets or sets the day 20.
        /// </summary>
        public AvailableStatus Day20 { get; set; }

        /// <summary>
        /// Gets or sets the day 21.
        /// </summary>
        public AvailableStatus Day21 { get; set; }

        /// <summary>
        /// Gets or sets the day 22.
        /// </summary>
        public AvailableStatus Day22 { get; set; }

        /// <summary>
        /// Gets or sets the day 23.
        /// </summary>
        public AvailableStatus Day23 { get; set; }

        /// <summary>
        /// Gets or sets the day 24.
        /// </summary>
        public AvailableStatus Day24 { get; set; }

        /// <summary>
        /// Gets or sets the day 25.
        /// </summary>
        public AvailableStatus Day25 { get; set; }

        /// <summary>
        /// Gets or sets the day 26.
        /// </summary>
        public AvailableStatus Day26 { get; set; }

        /// <summary>
        /// Gets or sets the day 27.
        /// </summary>
        public AvailableStatus Day27 { get; set; }

        /// <summary>
        /// Gets or sets the day 28.
        /// </summary>
        public AvailableStatus Day28 { get; set; }

        /// <summary>
        /// Gets or sets the day 29.
        /// </summary>
        public AvailableStatus Day29 { get; set; }

        /// <summary>
        /// Gets or sets the day 3.
        /// </summary>
        public AvailableStatus Day3 { get; set; }

        /// <summary>
        /// Gets or sets the day 30.
        /// </summary>
        public AvailableStatus Day30 { get; set; }

        /// <summary>
        /// Gets or sets the day 31.
        /// </summary>
        public AvailableStatus Day31 { get; set; }

        /// <summary>
        /// Gets or sets the day 4.
        /// </summary>
        public AvailableStatus Day4 { get; set; }

        /// <summary>
        /// Gets or sets the day 5.
        /// </summary>
        public AvailableStatus Day5 { get; set; }

        /// <summary>
        /// Gets or sets the day 6.
        /// </summary>
        public AvailableStatus Day6 { get; set; }

        /// <summary>
        /// Gets or sets the day 7.
        /// </summary>
        public AvailableStatus Day7 { get; set; }

        /// <summary>
        /// Gets or sets the day 8.
        /// </summary>
        public AvailableStatus Day8 { get; set; }

        /// <summary>
        /// Gets or sets the day 9.
        /// </summary>
        public AvailableStatus Day9 { get; set; }

        /// <summary>
        /// Gets or sets the hotel.
        /// </summary>
        public string Hotel { get; set; }

        /// <summary>
        /// Gets or sets the room.
        /// </summary>
        public string Room { get; set; }
    }

    /// <summary>
    /// The available status.
    /// </summary>
    public enum AvailableStatus
    {
        /// <summary>
        /// The available.
        /// </summary>
        Available = 0,

        /// <summary>
        /// The not available.
        /// </summary>
        NotAvailable = 1,

        /// <summary>
        /// The not available occupied.
        /// </summary>
        NotAvailableOccupied = 2,

        /// <summary>
        /// The not available billed.
        /// </summary>
        NotAvailableBilled = 3,

        /// <summary>
        /// The not existing day.
        /// </summary>
        NotExistingDay = 4
    }
}
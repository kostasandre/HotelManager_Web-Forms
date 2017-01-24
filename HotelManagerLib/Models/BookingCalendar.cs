using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagerLib.Models
{
    public class BookingCalendar
    {
        public int RoomId { get; set; }

        public AvailableStatus Day1 { get; set; }
        public AvailableStatus Day2 { get; set; }
        public AvailableStatus Day3 { get; set; }
        public AvailableStatus Day4 { get; set; }
        public AvailableStatus Day5 { get; set; }
        public AvailableStatus Day6 { get; set; }
        public AvailableStatus Day7 { get; set; }
        public AvailableStatus Day8 { get; set; }
        public AvailableStatus Day9 { get; set; }
        public AvailableStatus Day10 { get; set; }
        public AvailableStatus Day11 { get; set; }
        public AvailableStatus Day12 { get; set; }
        public AvailableStatus Day13 { get; set; }
        public AvailableStatus Day14 { get; set; }
        public AvailableStatus Day15 { get; set; }
        public AvailableStatus Day16 { get; set; }
        public AvailableStatus Day17 { get; set; }
        public AvailableStatus Day18 { get; set; }
        public AvailableStatus Day19 { get; set; }
        public AvailableStatus Day20 { get; set; }
        public AvailableStatus Day21 { get; set; }
        public AvailableStatus Day22 { get; set; }
        public AvailableStatus Day23 { get; set; }
        public AvailableStatus Day24 { get; set; }
        public AvailableStatus Day25 { get; set; }
        public AvailableStatus Day26 { get; set; }
        public AvailableStatus Day27 { get; set; }
        public AvailableStatus Day28 { get; set; }
        public AvailableStatus Day29 { get; set; }
        public AvailableStatus Day30 { get; set; }
        public AvailableStatus Day31 { get; set; }

    }

    public enum AvailableStatus
    {
        Available = 0,
        NotAvailable = 1,
        NotAvailableOccupied =2,
        NotAvailableBilled = 3

    }
}

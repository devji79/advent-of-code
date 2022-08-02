using System;
using System.Collections.Generic;
using System.Text;

namespace Day_5
{
    public class Seat
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public int SeatId
        {
            get
            {
                return (Row * 8) + Column;
            }
        }
    }
}

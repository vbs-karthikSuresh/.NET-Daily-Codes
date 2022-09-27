using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int? ShowId { get; set; }
        public int TotalTickets { get; set; }
        public double TotalCost { get; set; }
        public DateTime Date { get; set; }
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public string City { get; set; }
        public int ScreenNo { get; set; }
        public string UserName { get; set; }
        public int SeatNo1 { get; set; }
        public int SeatNo2 { get; set; }
        public int SeatNo3 { get; set; }

        public virtual Shows Show { get; set; }
        public virtual Users User { get; set; }
    }
}

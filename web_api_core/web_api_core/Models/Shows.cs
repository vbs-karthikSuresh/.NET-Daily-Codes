using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class Shows
    {
        public Shows()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public double Price { get; set; }
        public int ScreenNo { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual Theaters Theater { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}

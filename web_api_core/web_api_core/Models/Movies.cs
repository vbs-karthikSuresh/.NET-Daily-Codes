using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class Movies
    {
        public Movies()
        {
            Shows = new HashSet<Shows>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duretion { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string PosterUrl { get; set; }

        public virtual ICollection<Shows> Shows { get; set; }
    }
}

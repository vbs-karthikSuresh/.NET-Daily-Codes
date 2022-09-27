using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class Theaters
    {
        public Theaters()
        {
            Shows = new HashSet<Shows>();
        }

        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int NoOfScreen { get; set; }

        public virtual ICollection<Shows> Shows { get; set; }
    }
}

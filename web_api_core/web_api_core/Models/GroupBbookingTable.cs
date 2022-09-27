using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class GroupBbookingTable
    {
        public int Id { get; set; }
        public string Seatno { get; set; }
        public string UserId { get; set; }
        public DateTime Datetopresent { get; set; }
        public int MovieDetails { get; set; }
        public int Amount { get; set; }
        public int? MovieDetailsId { get; set; }
        public int? ApplicationUserUserId { get; set; }

        public virtual GroupBapplicationUser ApplicationUserUser { get; set; }
        public virtual GroupBmovieDetails MovieDetailsNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class GroupBmovieDetails
    {
        public GroupBmovieDetails()
        {
            GroupBbookingTable = new HashSet<GroupBbookingTable>();
        }

        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public DateTime DateAndTime { get; set; }
        public string MoviePicture { get; set; }

        public virtual ICollection<GroupBbookingTable> GroupBbookingTable { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class Vtcategory
    {
        public Vtcategory()
        {
            Vtpost = new HashSet<Vtpost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }

        public virtual ICollection<Vtpost> Vtpost { get; set; }
    }
}

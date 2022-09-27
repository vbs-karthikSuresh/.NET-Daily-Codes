using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class TrishaEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int? Salary { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class DeepakEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public DateTime? HireDate { get; set; }
        public int? Salary { get; set; }
        public int? DepartmentId { get; set; }

        public virtual DeepakDepartment Department { get; set; }
    }
}

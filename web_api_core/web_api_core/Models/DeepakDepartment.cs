using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class DeepakDepartment
    {
        public DeepakDepartment()
        {
            DeepakEmployee = new HashSet<DeepakEmployee>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<DeepakEmployee> DeepakEmployee { get; set; }
    }
}

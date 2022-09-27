﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace web_api_core.Models
{
    public partial class GroupBcart
    {
        public int Id { get; set; }
        public string Seatno { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }
    }
}

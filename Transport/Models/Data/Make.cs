﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Make
    {
        public Make()
        {
            Models = new HashSet<Model>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Status
    {
        public Status()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}

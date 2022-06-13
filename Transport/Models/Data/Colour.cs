using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Colour
    {
        public Colour()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int ColourId { get; set; }
        public string ColourName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class Model
    {
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}

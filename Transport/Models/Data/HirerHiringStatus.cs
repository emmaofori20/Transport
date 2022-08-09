using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class HirerHiringStatus
    {
        public int HirerHiringStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int HirerId { get; set; }
        public int? StatusId { get; set; }

        public virtual Hirer Hirer { get; set; }
        public virtual Status Status { get; set; }
    }
}

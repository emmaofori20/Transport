using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehicleDocument
    {
        public int VehicleDocumentId { get; set; }
        public string VehicleDocumentName { get; set; }
        public byte[] VehicleDocumentFile { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}

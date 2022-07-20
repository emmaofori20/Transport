using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class VehiclePhoto
    {
        public int VehiclePhotoId { get; set; }
        public string PhotoName { get; set; }
        public byte[] PhotoFile { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? VehicleId { get; set; }
        public int PhotoSectionId { get; set; }

        public virtual PhotoSection PhotoSection { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}

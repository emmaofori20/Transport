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
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}

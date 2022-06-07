using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class PhotoSection
    {
        public PhotoSection()
        {
            VehiclePhotos = new HashSet<VehiclePhoto>();
        }

        public int PhotoSectionId { get; set; }
        public string PhotoSectionName { get; set; }

        public virtual ICollection<VehiclePhoto> VehiclePhotos { get; set; }
    }
}

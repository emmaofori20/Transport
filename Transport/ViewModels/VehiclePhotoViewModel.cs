﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class VehiclePhotoViewModel
    {
        public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public byte[] PhotoFile { get; set; }
    }

}

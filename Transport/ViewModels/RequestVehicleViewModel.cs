﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class RequestVehicleViewModel
    {

        public RequestMaintenanceViewModel requestMaintenance { get; set; }

        public List< VehicleMaintenanceRequestsViewModel> VehicleMaintenanceRequests { get; set; }
    }
}
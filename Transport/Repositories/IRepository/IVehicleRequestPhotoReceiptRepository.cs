using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleRequestPhotoReceiptRepository
    {
        public void AddVehicleRequestPhotoReceipt(IFormFile formFile, int VehicleRequestId);

        
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleRequestPhotoReceiptRepository
    {
        public void AddVehicleRequestPhotoReceipt(IFormFile formFile, int VehicleRequestId);
        public GettingReceiptsViewModel GetReceiptsDocument(string DocumentStreamId);
        public VehicleRequestPhotoReceipt ImageExtension(string Id);
    }
}

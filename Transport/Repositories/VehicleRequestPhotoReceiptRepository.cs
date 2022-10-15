using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;

namespace Transport.Repositories
{
    public class VehicleRequestPhotoReceiptRepository: IVehicleRequestPhotoReceiptRepository
    {
        private readonly TransportDbContext _context;

        public VehicleRequestPhotoReceiptRepository(TransportDbContext context)
        {
            _context = context;

        }

        public void AddVehicleRequestPhotoReceipt(IFormFile formFile, int VehicleRequestId)
        {
            var VehicleRequestPhotoReceipt = new VehicleRequestPhotoReceipt()
            {
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                //ReceiptPhotoFile = ConvertToByte(formFile),
                VehicleMaintenanceRequestId = VehicleRequestId
                
            };

            _context.VehicleRequestPhotoReceipts.Add(VehicleRequestPhotoReceipt);
            _context.SaveChanges();
        }

        private byte[] ConvertToByte(IFormFile formFile)
        {
            byte[] fileBytes;

            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                fileBytes = stream.ToArray();
            }

            return fileBytes;
        }

    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.Utils;
using Transport.ViewModels;

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
            VehicleRequestPhotoReceipt vehicleRequestPhotoReceipt = new VehicleRequestPhotoReceipt()
            {
                VehicleMaintenanceRequestId = VehicleRequestId,
                FileName = formFile.FileName,
                CreatedOn = DateTime.Now,
                CreatedBy = "Admin",
                ReceiptPhotoStreamFileId = Guid.NewGuid().ToString()
            };
            _context.VehicleRequestPhotoReceipts.Add(vehicleRequestPhotoReceipt);
            UploadVehicleRequestDocumentToFileTable(vehicleRequestPhotoReceipt, ConvertToByte(formFile));
            _context.SaveChanges();

        }
        public InsertingDocumentViewModel UploadVehicleRequestDocumentToFileTable(VehicleRequestPhotoReceipt vehicleRequestPhotoReceipt, byte[] projectDocumentByte)
        {
            var result = _context.LoadStoredProc("usp_DOC_Insert")
               .WithSqlParam("UniqueIdentifier", vehicleRequestPhotoReceipt.ReceiptPhotoStreamFileId)
               .WithSqlParam("DocStream", projectDocumentByte)
               .WithSqlParam("DocName", vehicleRequestPhotoReceipt.FileName + vehicleRequestPhotoReceipt.ReceiptPhotoStreamFileId)
               .WithSqlParam("DocDescription", vehicleRequestPhotoReceipt.FileName)
               .ExecuteStoredProc<InsertingDocumentViewModel>().Single();

            return result;
        }

        public GettingReceiptsViewModel GetReceiptsDocument(string DocumentStreamId)
        {
            var result = _context.LoadStoredProc("usp_DOC_Fetch")
             .WithSqlParam("UniqueIdentifier", DocumentStreamId)
             .ExecuteStoredProc<GettingReceiptsViewModel>().Single();

            return result;
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

        public VehicleRequestPhotoReceipt ImageExtension(string Id)
        {
            return _context.VehicleRequestPhotoReceipts.Where(x => x.ReceiptPhotoStreamFileId == Id).FirstOrDefault();
        }
    }
}

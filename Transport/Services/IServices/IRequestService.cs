using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
    public interface IRequestService
    {
        public VehicleMaintenanceRequest MakeRequestMaintenance( RequestMaintenanceViewModel model);

        public void AddRequestSparePart(List<VehicleMaintananceSparepartViewModel> model, int SparePartListId, string Issuer);

        public VehicleMaintenanceRequestDetailsViewModel VehicleMaintenanceRequestDetails(int ListId);

        public (List<VehicleMaintenanceRequestsViewModel>, List<Vehicle>) GetAllVehicleMaintenanceRequest();

        public void DeleteVehicleRequestMaintenance(int RequestId, string Issuer);

        public void EdiVehicleRequestMaintenance(VehicleMaintenanceRequestDetailsViewModel model,int RequestId, string Issuer);

        public void UploadFiles(List<IFormFile> formFiles, int RequestId, string Issuer);
        public GettingReceiptsViewModel GetReceiptsDocument(string DocumentStreamId);

    }
}

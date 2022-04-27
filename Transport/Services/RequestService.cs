using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Services
{
    public class RequestService:IRequestService
    {
        private readonly IVehicleMaintenanceRequestRepository vehicleMaintenanceRequestRepository;
        private readonly IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository;
        private readonly IVehicleMaintenanceSparePartRepository vehicleMaintenanceSparePartRepository;

        public RequestService(IVehicleMaintenanceRequestRepository vehicleMaintenanceRequestRepository, 
                               IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository,
                                IVehicleMaintenanceSparePartRepository vehicleMaintenanceSparePartRepository)
        {
            this.vehicleMaintenanceRequestRepository = vehicleMaintenanceRequestRepository;
            this.vehicleMaintenanceRequestStatusRepository = vehicleMaintenanceRequestStatusRepository;
            this.vehicleMaintenanceSparePartRepository = vehicleMaintenanceSparePartRepository;
        }

        public VehicleMaintenanceRequest MakeRequestMaintenance(RequestMaintenanceViewModel model)
        {
            //Register the vehicle into the VehicleRequestMaintenance
            var VehicleMaintenanceRequest=  vehicleMaintenanceRequestRepository
                                                    .VehicleMaintenanceRequest(model);
            //setting the status of the request
            vehicleMaintenanceRequestStatusRepository.PendingVehicleMaintenanceRequestStatus(VehicleMaintenanceRequest.VehicleMaintenanceRequestId);
            return VehicleMaintenanceRequest;
        }

        public void AddRequestSparePart(List<VehicleMaintananceSparepartViewModel> model, int SparePartListId)
        {
            //Adding List to the table
            for (int i = 0; i < model.Count; i++)
            {
                vehicleMaintenanceSparePartRepository.AddVehicleMaintenanceSparePart(model[i], SparePartListId);
            }

        }

        public VehicleMaintenanceRequestDetailsViewModel VehicleMaintenanceRequestDetails(int ListId)
        {
            //Veiwing the details of a request List or an Invoice List
            var requestStatus = vehicleMaintenanceRequestStatusRepository.GetVehicleMaintenanceRequestStatus(ListId);
            var requestList = vehicleMaintenanceSparePartRepository.GetList(ListId);
            var requestMaintenance = vehicleMaintenanceRequestRepository.GetMaintenanceRequest(ListId);

            List<VehicleMaintananceSparepartViewModel> _spareParts= new List<VehicleMaintananceSparepartViewModel>(); ;

            //For loop to get Spare part and Quantity from the total list
            for (int i = 0; i < requestList.Count; i++)
            {
                VehicleMaintananceSparepartViewModel sparepart = new VehicleMaintananceSparepartViewModel
                {
                    Quantity = requestList[i].Quantity,
                    SparePartName = requestList[i].NameOfPart,
                    Amount = (double)requestList[i].Amount
                };

                _spareParts.Add(sparepart);
            }

            //Preparing the List
            var Details = new VehicleMaintenanceRequestDetailsViewModel
            {
                MaintainedBy= requestMaintenance.MaintainedBy,
                MaintenanceCost = requestMaintenance.MainteinanceCost,
                MaintenanceDescription = requestMaintenance.MaintenanceDescription,
                RegistrationNumber = requestMaintenance.VehicleId,//later change to string
                Status = requestStatus.MaintainanceStatus.StatusName,
                Date = requestMaintenance.CreatedOn,
                RequestId= requestMaintenance.VehicleMaintenanceRequestId,
                spareParts = _spareParts
            };

            return Details;
        }

        public List<VehicleMaintenanceRequestsViewModel> GetAllVehicleMaintenanceRequest()
        {
            //get all request and store in list
            var AllvehicleMaintenanceRequest = vehicleMaintenanceRequestRepository.GetAllMaintenanceRequest();
            List<VehicleMaintenanceRequestsViewModel> AllRequestList = new List<VehicleMaintenanceRequestsViewModel>(); ;

            for (int i = 0; i < AllvehicleMaintenanceRequest.Count; i++)
            {
                //preapring all the list
                //Preparing the List
                var singleRequestDetals = new VehicleMaintenanceRequestsViewModel
                {
                    MaintainedBy = AllvehicleMaintenanceRequest[i].MaintainedBy,
                    MaintenanceCost = AllvehicleMaintenanceRequest[i].MainteinanceCost,
                    RegistrationNumber = AllvehicleMaintenanceRequest[i].VehicleId  ,//later change to string                    
                   /* Status = AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestStatuses
                                            .OrderBy(x => x.CreatedOn)
                                            .FirstOrDefault(x => x.VehicleMaintenanceRequestId == AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestId)
                                            .MaintainanceStatus.StatusName,*/// getting status name
                    spareParts = AllvehicleMaintenanceRequest[i].VehicleMaintenanceSpareparts
                                            .Where(x=>x.VehicleMaintenanceRequestId == AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestId)
                                            .Count(),//getting total list of spareprt to display number
                    RequestId = AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestId,
                    Date = AllvehicleMaintenanceRequest[i].CreatedOn
                    
                };

                AllRequestList.Add(singleRequestDetals);

                

            }

            return AllRequestList;
        }

        public void DeleteVehicleRequestMaintenance(int RequestId)
        {
            vehicleMaintenanceRequestRepository.DeleteVehicleRequestMaintenance(RequestId);
        }
    }
}

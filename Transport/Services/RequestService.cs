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
                MaintenanceDescription = requestMaintenance.MaintenanceDescription,
                RegistrationNumber = requestMaintenance.VehicleId,//later change to string
                Status = requestStatus.MaintenanceStatus.StatusName,
                Date = requestMaintenance.CreatedOn,
                RequestId= requestMaintenance.VehicleMaintenanceRequestId,
                spareParts = _spareParts,
                MaintainedBy = requestMaintenance.CreatedBy
                
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
                    RegistrationNumber = AllvehicleMaintenanceRequest[i].VehicleId  ,//later change to string                    
                    Status = AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestStatuses
                                            .OrderByDescending(x => x.CreatedOn)
                                            .FirstOrDefault(x => x.VehicleMaintenanceRequestId == AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestId)
                                            .MaintenanceStatus.StatusName,// getting status name
                    spareParts = AllvehicleMaintenanceRequest[i].VehicleMaintenanceSpareparts
                                            .Where(x=>x.VehicleMaintenanceRequestId == AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestId)
                                            .Count(),//getting total list of spareprt to display number
                    RequestId = AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestId,
                    Date = AllvehicleMaintenanceRequest[i].CreatedOn,
                    MaintainedBy = AllvehicleMaintenanceRequest[i].CreatedBy,
                    MaintenanceCost = AllvehicleMaintenanceRequest[i].VehicleMaintenanceSpareparts
                    .Where(x => x.VehicleMaintenanceRequestId == AllvehicleMaintenanceRequest[i].VehicleMaintenanceRequestId)
                    .Sum(c=>c.Amount*c.Quantity)
                };

                AllRequestList.Add(singleRequestDetals);

                

            }

            return AllRequestList;
        }

        public void DeleteVehicleRequestMaintenance(int RequestId)
        {
            vehicleMaintenanceRequestRepository.DeleteVehicleRequestMaintenance(RequestId);
        }

        public void EdiVehicleRequestMaintenance(VehicleMaintenanceRequestDetailsViewModel model, int RequestId)
        {
            //......UPDATE ON THE REQUEST........//
            var RequestMaintenance = new RequestMaintenanceViewModel
            {
                MaintenanceDescription = model.MaintenanceDescription,
                RegistrationNumber = "1",///change in the futre

            };
            vehicleMaintenanceRequestRepository.EditVehicleRequestMaintenance(RequestId, RequestMaintenance);
            //......UPDATE ON THE REQUEST........//


            ////////////UPDATE OF THE SPARE PART SECTION////////////
            //Deleting all spareparts with the request ID
            vehicleMaintenanceSparePartRepository.DeleteAllVehicleMaintenanceSparepart(RequestId);
            //update/ addng new spareprts
            AddRequestSparePart(model.spareParts, RequestId);
            ////////////UPDATE OF THE SPARE PART SECTION////////////

        }
    }
}

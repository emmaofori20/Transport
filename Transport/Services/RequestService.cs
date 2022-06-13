using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IVehicleRepository vehicleRepository;

        public RequestService(IVehicleMaintenanceRequestRepository vehicleMaintenanceRequestRepository, 
                               IVehicleMaintenanceRequestStatusRepository vehicleMaintenanceRequestStatusRepository,
                                IVehicleMaintenanceSparePartRepository vehicleMaintenanceSparePartRepository,
                                IVehicleRepository vehicleRepository)
        {
            this.vehicleMaintenanceRequestRepository = vehicleMaintenanceRequestRepository;
            this.vehicleMaintenanceRequestStatusRepository = vehicleMaintenanceRequestStatusRepository;
            this.vehicleMaintenanceSparePartRepository = vehicleMaintenanceSparePartRepository;
            this.vehicleRepository = vehicleRepository;
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
                RegistrationNumber = requestMaintenance.Vehicle.RegistrationNumber,//later change to string
                Status = requestStatus.MaintenanceStatus.StatusName,
                Date = requestMaintenance.CreatedOn,
                RequestId= requestMaintenance.VehicleMaintenanceRequestId,
                spareParts = _spareParts,
                MaintainedBy = requestMaintenance.CreatedBy,
                VehicleId = requestMaintenance.VehicleId,
                ///////////THIIS VARIABLE IS FOR THE EDITING OF  REQUEST MAINTENANCE SPARE PARTS////////
                AllVehicles = new SelectList(GetAllVehicleMaintenanceRequest().Item2
                                                    .Select(s => new { VehicleId = s.VehicleId, RegistrationNumber = $"{s.RegistrationNumber}", ChasisNumber = $"{s.ChasisNumber}" }), "VehicleId", "RegistrationNumber", "ChasisNumber")
                ///////////THIIS VARIABLE IS FOR THE EDITING OF  REQUEST MAINTENANCE SPARE PARTS////////


            };

            return Details;
        }

        public (List<VehicleMaintenanceRequestsViewModel>, List<Vehicle> ) GetAllVehicleMaintenanceRequest()
        {
            //get all request and store in list
            var AllvehicleMaintenanceRequest = vehicleMaintenanceRequestRepository.GetAllMaintenanceRequest();
            List<VehicleMaintenanceRequestsViewModel> AllRequestList = new List<VehicleMaintenanceRequestsViewModel>(); ;

            //set a list of v

            for (int i = 0; i < AllvehicleMaintenanceRequest.Count; i++)
            {
                //preapring all the list
                //Preparing the List
                var singleRequestDetals = new VehicleMaintenanceRequestsViewModel
                {
                    RegistrationNumber = AllvehicleMaintenanceRequest[i].Vehicle.RegistrationNumber,
                    VehicleId = AllvehicleMaintenanceRequest[i].VehicleId,                 
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
            //////GETTING ALL THE LIST OF THE VEHICLE TO SET INCASE A USER MAKES A REQUEST MAINTENANCE
            var vehicleList = vehicleRepository.GetAllVehicles().Result.Item2;
            //////GETTING ALL THE LIST OF THE VEHICLE TO SET INCASE A USER MAKES A REQUEST MAINTENANCE

            return (AllRequestList,vehicleList);
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
                RegistrationNumber = model.VehicleId,///change in the futre

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

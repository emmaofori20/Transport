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
    public class HiringService: IHiringService
    {
        private readonly IVehicleTypeForHireRepository vehicleTypeForHireRepository;
        private readonly IHirerRepository hirerRepository;
        private readonly IRequestService requestService;
        private readonly IBusHiringDistanceRepository busHiringDistanceRepository;
        private readonly IBusHiringPricesRepository busHiringPrices;

        public HiringService(IVehicleTypeForHireRepository vehicleTypeForHireRepository,
            IHirerRepository hirerRepository,IRequestService requestService, 
            IBusHiringDistanceRepository busHiringDistanceRepository,
            IBusHiringPricesRepository busHiringPrices)
        {
            this.vehicleTypeForHireRepository = vehicleTypeForHireRepository;
            this.hirerRepository = hirerRepository;
            this.requestService = requestService;
            this.busHiringDistanceRepository = busHiringDistanceRepository;
            this.busHiringPrices = busHiringPrices;
        }

        public HiringTableMatrixViewModel GetHiringTableMatrix()
        {
            List<BusHiringPriceViewModel> _busHiringPrices = new List<BusHiringPriceViewModel>();
            var VehicleTypeForHires = vehicleTypeForHireRepository.GetVehicleTypeForHire();
            var BusHiringDistances = busHiringDistanceRepository.GetBusHiringDistance();
            var BusHiringPrices = busHiringPrices.GetBusHiringPrice();

            for (int i = 0; i < BusHiringDistances.Count; i++)
            {
                for (int y= 0; y < VehicleTypeForHires.Count; y++)
                {
                    var bushiringprice = BusHiringPrices
                            .Where(x => x.VehicleTypeForHireId == VehicleTypeForHires[y].VehicleTypeForHireId
                            && x.BusHiringDistanceId == BusHiringDistances[i].BusHiringDistanceId).FirstOrDefault();
          
                    var newitem = new BusHiringPriceViewModel()
                    {
                        BusHiringDistanceId = BusHiringDistances[i].BusHiringDistanceId,
                        VehicleTypeForHireId = VehicleTypeForHires[y].VehicleTypeForHireId,
                        BusHirngPriceId = bushiringprice == null ? 0 : bushiringprice.BusHiringPriceId ,
                        Price = bushiringprice == null? 0: bushiringprice.Price
                    };
                    _busHiringPrices.Add(newitem);
                }
            }
            return new HiringTableMatrixViewModel()
            {
                VehicleTypeForHires = vehicleTypeForHireRepository.GetVehicleTypeForHire(),
                BusHiringDistances = busHiringDistanceRepository.GetBusHiringDistance(),
                BusHiringPrices = busHiringPrices.GetBusHiringPrice(),
                BusPricesForDistanceAndVehicleType = _busHiringPrices
            };
        }

        public void SaveHiringPricesDetails(HiringTableMatrixViewModel model)
        {
            foreach (var item in model.Prices)
            {

            }
        }
        //Approving a hire request
        public void ApproveHireRequest(List<ApproveHireRequest> model)
        {
            //For the number of busses requested for hiring
            for (int i = 0; i < model.Count; i++)
            {
                hirerRepository.ApprovedHire(model[i]);
            }
            hirerRepository.SetHirerHiringStatusToApproved(model[0].HirerId);
        }

        public List<HireDetailsViewModel> GetAllHirers()
        {
            //get all Hiring Request and store in list
            var AllHiringRequest = hirerRepository.GetAllHirers();
            List<HireDetailsViewModel> hirerDetailsViewModels = new List<HireDetailsViewModel>();
            //////PREPARING LIST FOR A SINGLE Hire LIST//////
            for (int i = 0; i < AllHiringRequest.Count; i++)
            {
                var singleHireDetails = new HireDetailsViewModel()
                {
                    OrganisationName = AllHiringRequest[i].OrganisationName,
                    ContactName = AllHiringRequest[i].ContactName,
                    PostalAddress = AllHiringRequest[i].PostalAddress,
                    PrimaryContactNumber = AllHiringRequest[i].PrimaryContactNumber,
                    OtherContactNumber = AllHiringRequest[i].OtherContactNumber,
                    Email = AllHiringRequest[i].Email,
                    StartDate = AllHiringRequest[i].StartDate,
                    StartTime = AllHiringRequest[i].StartTime,
                    FinishDate = AllHiringRequest[i].FinishDate,
                    FinishTime = AllHiringRequest[i].FinishTime,
                    PurposeOfHire = AllHiringRequest[i].PurposeOfHire,
                    Destination = AllHiringRequest[i].Destination,
                    NoOfBusses = (int)AllHiringRequest[i].NoOfBusses,
                    HirerId = AllHiringRequest[i].HirerId,
                    NoOfPassangers = (int)AllHiringRequest[i].NoOfPassengers,
                    VehicleTypeForHireType = AllHiringRequest[i].VehicleTypeForHire.VehicleType,
                    VehicleTypeForHireId = AllHiringRequest[i].VehicleTypeForHireId,
                    DistanceCalculatedFromOrginCost = (decimal)AllHiringRequest[i].DistanceCalaculatedFromOriginCost,
                    //DistanceCalculatedFromOrigin = AllHiringRequest[i].DistanceCalculatedFromOrigin,
                    ////////Getting Status Name/////////////////
                    Status = AllHiringRequest[i].HirerHiringStatuses.OrderByDescending(x=>x.CreatedOn)
                                .FirstOrDefault(x=>x.HirerId == AllHiringRequest[i].HirerId).Status.StatusName,
                    ////////Getting Status Name/////////////////
                    CreatedOn = DateTime.Now,
                    CreatedBy = AllHiringRequest[i].ContactName,
                    
                };
                hirerDetailsViewModels.Add(singleHireDetails);


            }
            return hirerDetailsViewModels;
        }

        //Getting a single hire details
        public ApproveHiringRequestViewModel GetSingleHireDetails(int HirerId)
        {
            //Get the HIre details
            var AllHireDetails = GetAllHirers();
            HireDetailsViewModel singleHireDetails = AllHireDetails.Where(x => x.HirerId == HirerId).FirstOrDefault();
            var AllHiring = hirerRepository.AllHiring().Where(x => x.HirerId == HirerId).ToList();
            List<ApproveHireRequest> AllApprovedHireRequests = new List<ApproveHireRequest>();
            //Getting all approved hiring details
            for (int i = 0; i < AllHiring.Count; i++)
            {
                ApproveHireRequest _approveHireRequest = new ApproveHireRequest()
                {

                    HirerId = singleHireDetails.HirerId,
                    HireCostFee = singleHireDetails.DistanceCalculatedFromOrginCost,
                    Vehicles = new SelectList(requestService
                                        .GetAllVehicleMaintenanceRequest().Item2
                                        .Select(s => new { VehicleId = s.VehicleId, RegistrationNumber = $"{s.RegistrationNumber}", ChasisNumber = $"{s.ChasisNumber}" }), "VehicleId", "RegistrationNumber", "ChasisNumber"),
                    WashingFee = (decimal)AllHiring[i].WashingFee,
                    DriverFee = (decimal)AllHiring[i].DriverHireFee ,
                    VehicleId = AllHiring[i].VehicleId,
                    RegistrationNumber = AllHiring[i].Vehicle.RegistrationNumber,
                    TotalPrice =AllHiring[i].TotalHirePrice
                };
                AllApprovedHireRequests.Add(_approveHireRequest);

            }
            ApproveHiringRequestViewModel approveHiringRequestViewModel = new ApproveHiringRequestViewModel
            {
                hireDetails = singleHireDetails,
                approveHireRequest = AllApprovedHireRequests,
                Vehicles = new SelectList(requestService
                                        .GetAllVehicleMaintenanceRequest().Item2
                                        .Select(s => new { VehicleId = s.VehicleId, RegistrationNumber = $"{s.RegistrationNumber}", ChasisNumber = $"{s.ChasisNumber}" }), "VehicleId", "RegistrationNumber", "ChasisNumber"),

            };
          
            return approveHiringRequestViewModel;
        }

        public void SetHireBus(HireDetailsViewModel model)
        {
            hirerRepository.SetHirerDetails(model);
        }

        public HireDetailsViewModel SetVehiclesForHire()
        {
            HireDetailsViewModel hireBusViewModel = new HireDetailsViewModel()
            {
                vehicleTypeForHire = new SelectList(vehicleTypeForHireRepository.GetVehicleTypeForHire()
                                                        .Select(s => new { VehicleTypeForHireId = s.VehicleTypeForHireId, VehicleType = $"{s.VehicleType}" }), "VehicleTypeForHireId", "VehicleType")
            };

            return hireBusViewModel;
        }
    }
}

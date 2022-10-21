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
        private readonly ITransportStaffRepository transportStaff;

        public HiringService(IVehicleTypeForHireRepository vehicleTypeForHireRepository,
            IHirerRepository hirerRepository,IRequestService requestService, 
            IBusHiringDistanceRepository busHiringDistanceRepository,
            IBusHiringPricesRepository busHiringPrices,
            ITransportStaffRepository transportStaff)
        {
            this.vehicleTypeForHireRepository = vehicleTypeForHireRepository;
            this.hirerRepository = hirerRepository;
            this.requestService = requestService;
            this.busHiringDistanceRepository = busHiringDistanceRepository;
            this.busHiringPrices = busHiringPrices;
            this.transportStaff = transportStaff;
        }

        public HiringTableMatrixViewModel GetHiringTableMatrix()
        {
            List<BusHiringPriceViewModel> _busHiringPrices = new List<BusHiringPriceViewModel>();
            var VehicleTypeForHires = vehicleTypeForHireRepository.GetVehicleTypeForHire();
            var BusHiringDistances = busHiringDistanceRepository.GetBusHiringDistance();
            var BusHiringPrices = busHiringPrices.GetBusHiringPrice();

            for (int i = 0; i < VehicleTypeForHires.Count; i++)
            {
                for (int y= 0; y < BusHiringDistances.Count; y++)
                {
                    var bushiringprice = BusHiringPrices
                            .Where(x => x.VehicleTypeForHireId == VehicleTypeForHires[i].VehicleTypeForHireId
                            && x.BusHiringDistanceId == BusHiringDistances[y].BusHiringDistanceId).FirstOrDefault();
          
                    var newitem = new BusHiringPriceViewModel()
                    {
                        BusHiringDistanceId = BusHiringDistances[y].BusHiringDistanceId,
                        VehicleTypeForHireId = VehicleTypeForHires[i].VehicleTypeForHireId,
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
            foreach (var item in model.BusPricesForDistanceAndVehicleType)
            {
                busHiringPrices.saveBusHiringPrice(item);
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

            //Setting the Hirer's status to Approved 
            //functions also updates the TotalCost for hiring for hirer
            hirerRepository.SetHirerHiringStatusToApproved(model[0]);
        }

        public List<HireDetailsViewModel> GetAllHirers()
        {
            //get all Hiring Request and store in list
            var AllHiringRequest = hirerRepository.GetAllHirers();
            List<HireDetailsViewModel> hirerDetailsViewModels = new List<HireDetailsViewModel>();
            //////PREPARING LIST FOR A SINGLE Hire LIST//////
            for (int i = 0; i < AllHiringRequest.Count; i++)
            {
                var singleHireDetails = new HireDetailsViewModel();

                singleHireDetails.OrganisationName = AllHiringRequest[i].OrganisationName;
                singleHireDetails.ContactName = AllHiringRequest[i].ContactName;
                singleHireDetails.PostalAddress = AllHiringRequest[i].PostalAddress;
                singleHireDetails.PrimaryContactNumber = AllHiringRequest[i].PrimaryContactNumber;
                singleHireDetails.OtherContactNumber = AllHiringRequest[i].OtherContactNumber;
                singleHireDetails.Email = AllHiringRequest[i].Email;
                singleHireDetails.StartDate = AllHiringRequest[i].StartDate;
                singleHireDetails.StartTime = AllHiringRequest[i].StartTime;
                singleHireDetails.FinishDate = AllHiringRequest[i].FinishDate;
                singleHireDetails.FinishTime = AllHiringRequest[i].FinishTime;
                singleHireDetails.PurposeOfHire = AllHiringRequest[i].PurposeOfHire;
                singleHireDetails.Destination = AllHiringRequest[i].Destination;
                singleHireDetails.NoOfBusses = (int)AllHiringRequest[i].NoOfBusses;
                     singleHireDetails.HirerId = AllHiringRequest[i].HirerId;
                     singleHireDetails.NoOfPassangers = (int)AllHiringRequest[i].NoOfPassengers;
                     singleHireDetails.VehicleTypeForHireType = AllHiringRequest[i].VehicleTypeForHire.VehicleType;
                     singleHireDetails.VehicleTypeForHireId = AllHiringRequest[i].VehicleTypeForHireId;
                     singleHireDetails.DistanceCalculatedFromOrginCost = (decimal)AllHiringRequest[i].DistanceCalaculatedFromOriginCost;
                     singleHireDetails.DistanceCalculatedFromOrigin = (decimal)AllHiringRequest[i].DistanceCalculatedFromOrigin;
                    ////////Getting Status Name/////////////////
                     singleHireDetails.Status = AllHiringRequest[i].HirerHiringStatuses.OrderByDescending(x => x.CreatedOn)
                                .Where(x => x.HirerId == AllHiringRequest[i].HirerId).FirstOrDefault().Status.StatusName;
                    ////////Getting Status Name/////////////////
                     singleHireDetails.CreatedOn = DateTime.Now;
                     singleHireDetails.CreatedBy = AllHiringRequest[i].ContactName;
                     singleHireDetails.TotalHiringCost = (decimal)AllHiringRequest[i].TotalHiringCost ;

            
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
                    CalculatedCost = singleHireDetails.TotalHiringCost,
                    WashingFee = (decimal)AllHiring[i].WashingFee,
                    DriverFee = (decimal)AllHiring[i].DriverHireFee ,
                    VehicleId = AllHiring[i].VehicleId,
                    DriverId = AllHiring[i].TransportStaffId,
                    RegistrationNumber = AllHiring[i].Vehicle.RegistrationNumber,
                    DriverName = AllHiring[i].TransportStaff.Othernames + " " + AllHiring[i].TransportStaff.Surname,
                    DateTimeReturned = (DateTime)AllHiring[i].TimeReturned
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
                Drivers = new SelectList(transportStaff
                                        .GetAllTransportStaff()
                                        .Select(d => new { TransportStaffId = d.TransportStaffId, FullName = $"{d.Othernames +" "+ d.Surname }", }), "TransportStaffId", "FullName")
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

        public void CompleteHireRequest(CompletedHireRequest model)
        {
            hirerRepository.CompleteHire(model);
        }

        public void InvalidHireRequest(List<ApproveHireRequest> model)
        {
            hirerRepository.InvalidHire(model[0]);
        }
    }
}

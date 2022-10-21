using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class HirerRepository: IHirerRepository
    {
        private readonly TransportDbContext _context;

        public HirerRepository(TransportDbContext context)
        {
            _context = context;

        }

        public List<Hirer> GetAllHirers()
        {
            return _context.Hirers.Include(x => x.VehicleTypeForHire)
                .Include(x => x.HirerHiringStatuses).ThenInclude(x => x.Status).ToList();
        }

        public List<Hiring> AllHiring()
        {
            return _context
                .Hirings
                .Include(x=>x.Vehicle)
                .Include(x=>x.TransportStaff)
                .Include(x=>x.Hirer)
                .ToList();
        }

        public List<HirerHiringStatus> GetAllHireHiringStatus()
        {
            return _context.HirerHiringStatuses.ToList();
        }

        public void SetHirerDetails(HireDetailsViewModel model)
        {
            decimal Hireprice= CalculateBusHiringPrices(model.VehicleTypeForHireId, (double)model.DistanceCalculatedFromOrigin);
            var hirer = new Hirer()
            {
                OrganisationName = model.OrganisationName,
                ContactName = model.ContactName,
                PostalAddress = model.PostalAddress,
                PrimaryContactNumber = model.PrimaryContactNumber,
                OtherContactNumber = model.OtherContactNumber,
                Email = model.Email,
                StartDate = model.StartDate,
                StartTime = model.StartTime,
                FinishDate = model.FinishDate,
                FinishTime = model.FinishTime,
                PurposeOfHire = model.PurposeOfHire,
                Destination = model.Destination,
                NoOfBusses = model.NoOfBusses,
                NoOfPassengers = model.NoOfPassangers,
                VehicleTypeForHireId = model.VehicleTypeForHireId,
                CreatedOn = DateTime.Now,
                CreatedBy = model.ContactName,
                DistanceCalculatedFromOrigin = model.DistanceCalculatedFromOrigin,
                DistanceCalaculatedFromOriginCost = Hireprice,
                TotalHiringCost = 0

            };

            _context.Hirers.Add(hirer);
            _context.SaveChanges();

            SetHirerHiringStatusToPending(hirer.HirerId);
        }

        public void SetHirerHiringStatusToPending(int hirerId)
        {
            var hirerHiringStatus = new HirerHiringStatus()
            {
                HirerId = hirerId,
                StatusId = 2003,
                CreatedBy = "AdminHire",
                CreatedOn = DateTime.Now,
               
            };

            _context.HirerHiringStatuses.Add(hirerHiringStatus);
            _context.SaveChanges();
        }
        public decimal CalculateBusHiringPrices(int VehicleTypeForHireId, double DistanceCalculated)
        {
            //get BusHiringDistances Id
            var BusHiringDistanceId= _context.BusHiringDistances
                .Where(x => x.MinimumDistance <= DistanceCalculated && x.MaximumDistance >= DistanceCalculated)
                .FirstOrDefault().BusHiringDistanceId;
            //get BusHiringPrices Id
            var BusHiringPrice = _context.BusHiringPrices
                .Where(x => x.BusHiringDistanceId == BusHiringDistanceId && x.VehicleTypeForHireId == VehicleTypeForHireId)
                .FirstOrDefault();
            //get Hire price
            decimal HirePrice = (decimal)(BusHiringPrice == null? 0: BusHiringPrice.Price);
            return HirePrice;
        }
        public void ApprovedHire(ApproveHireRequest model)
        {
            //We set each vehicle in the hirings table
            var hiring = new Hiring()
            {
                HirerId = model.HirerId,
                TimeHired = DateTime.Now,
                //TotalHirePrice = model.HireCostFee + model.WashingFee + model.DriverFee,
                //HireCostFee = model.HireCostFee,
                WashingFee = model.WashingFee,
                DriverHireFee = model.DriverFee,
                CreatedBy ="Admin",
                CreatedOn = DateTime.Now,
                VehicleId = model.VehicleId,
                TransportStaffId = model.DriverId,
                TimeReturned = DateTime.Now
            };

            _context.Hirings.Add(hiring);
            _context.SaveChanges();

        }

        public void SetHirerHiringStatusToApproved (ApproveHireRequest hirer)
        {
            var hirerHiringStatus = new HirerHiringStatus()
            {
                HirerId = hirer.HirerId,
                StatusId = 2005,
                CreatedBy = "AdminHire",
                CreatedOn = DateTime.Now,

            };
            UpdateHirerTotalCost(hirer.HirerId, hirer.CalculatedCost);
            _context.HirerHiringStatuses.Add(hirerHiringStatus);
            _context.SaveChanges();
        }

        public void UpdateHirerTotalCost(int hirerId, decimal cost)
        {
            var res = _context.Hirers.Find(hirerId);
            if (res != null)
            {
                res.TotalHiringCost = cost;
                _context.Hirers.Update(res);
                _context.SaveChanges();
            }
        }

        public void CompleteHire(CompletedHireRequest model)
        {
            var res = _context.Hirings.Where(x => x.HirerId == model.HirerId).ToList();
            if(res!= null)
            {
                foreach (var item in res)
                {
                    item.TimeReturned = model.DateTimeReturned;
                    item.UpdatedBy = "Admni";
                    item.UpdatedOn = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                };

                //set status to completed
                _context.HirerHiringStatuses.Add(new HirerHiringStatus
                {
                    HirerId = model.HirerId,
                    StatusId = 2006,
                    CreatedBy = "AdminHire",
                    CreatedOn = DateTime.Now,
                });
                _context.SaveChanges();
            }
        }

        public void InvalidHire(ApproveHireRequest model)
        {
            var hirerHiringStatus = new HirerHiringStatus()
            {
                HirerId = model.HirerId,
                StatusId = 2007,
                CreatedBy = "AdminHire",
                CreatedOn = DateTime.Now,

            };

            _context.HirerHiringStatuses.Add(hirerHiringStatus);
            _context.SaveChanges();
        }
    }
}

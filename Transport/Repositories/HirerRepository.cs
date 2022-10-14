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
            return _context.Hirings.ToList();
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
                DistanceCalaculatedFromOriginCost = Hireprice

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
                .FirstOrDefault().Price;
            //get Hire price
            decimal HirePrice = (decimal)BusHiringPrice;
            return HirePrice;
        }
        public void ApprovedHire(ApproveHireRequest model)
        {
            //We set each vehicle in the hirings table
            var hiring = new Hiring()
            {
                HirerId = model.HirerId,
                TimeHired = DateTime.Now,
                TotalHirePrice = model.HireCostFee + model.WashingFee + model.DriverFee,
                HireCostFee = model.HireCostFee,
                WashingFee = model.WashingFee,
                DriverHireFee = model.DriverFee,
                CreatedBy ="Admin",
                CreatedOn = DateTime.Now,
                VehicleId = model.VehicleId
            };

            _context.Hirings.Add(hiring);
            _context.SaveChanges();

        }

        public void SetHirerHiringStatusToApproved (int hirerId)
        {
            var hirerHiringStatus = new HirerHiringStatus()
            {
                HirerId = hirerId,
                StatusId = 2005,
                CreatedBy = "AdminHire",
                CreatedOn = DateTime.Now,

            };

            _context.HirerHiringStatuses.Add(hirerHiringStatus);
            _context.SaveChanges();
        }
    }
}

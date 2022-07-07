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
                .Include(x => x.HirerHiringStatuses).ThenInclude(x => x.HiringStatus).ToList();
        }

        public List<HirerHiringStatus> GetAllHireHiringStatus()
        {
            return _context.HirerHiringStatuses.ToList();
        }


        public void SetHirerDetails(HireDetailsViewModel model)
        {
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
                HiringStatusId = 40000,
                CreatedBy = "AdminHire",
                CreatedOn = DateTime.Now,
               
            };

            _context.HirerHiringStatuses.Add(hirerHiringStatus);
            _context.SaveChanges();
        }
    }
}

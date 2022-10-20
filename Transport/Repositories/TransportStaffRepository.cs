using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Extensions;
using Transport.Models.Data;
using Transport.Repositories.IRepository;
using Transport.ViewModels;

namespace Transport.Repositories
{
    public class TransportStaffRepository : ITransportStaffRepository
    {
        private readonly TransportDbContext _context;

        public TransportStaffRepository(TransportDbContext context)
        {
            _context = context;
        }

        public List<TransportStaff> GetAllTransportStaff()
        {
            return _context.TransportStaffs.ToList();
        }
        //public List<TransportStaffViewModel> GetAll()
        //{
        //    var result = _context.LoadStoredProc("usp_GetAllTransportStaff")

        //        .ExecuteStoredProc<TransportStaffViewModel>().ToList();

        //    return result;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Repositories.IRepository;
using Transport.Services.IServices;
using Transport.ViewModels;

namespace Transport.Services
{
    public class AdminService: IAdminService
    {
        private readonly ITransportStaffRepository transportStaffRepository;

        public AdminService(ITransportStaffRepository transportStaffRepository )
        {
            this.transportStaffRepository = transportStaffRepository;
        }

        public List<TransportStaffViewModel> GetAllTransportStaff()
        {
            throw new NotImplementedException();
        }
        //public List<TransportStaffViewModel> GetAllTransportStaff()
        //{
        //    //return transportStaffRepository.GetAll();
        //}
    }
}

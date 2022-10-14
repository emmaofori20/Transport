using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
   public interface IAdminService
    {
        public List<TransportStaffViewModel> GetAllTransportStaff();

    }
}

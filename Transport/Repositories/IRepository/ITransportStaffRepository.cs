using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface ITransportStaffRepository
    {
        public List<TransportStaffViewModel> GetAll();
    }
}

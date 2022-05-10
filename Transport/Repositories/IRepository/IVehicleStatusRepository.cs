using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IVehicleStatusRepository
    {
        public SelectList GetAllVehicleStatuses();
    }
}

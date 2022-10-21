using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Services.IServices
{
   public interface IHiringService
    {
        public HireDetailsViewModel SetVehiclesForHire();
        public void SetHireBus( HireDetailsViewModel model);
        public List<HireDetailsViewModel> GetAllHirers();
        public ApproveHiringRequestViewModel GetSingleHireDetails(int HirerId);
        public void ApproveHireRequest(List<ApproveHireRequest> model);
        public void InvalidHireRequest(List<ApproveHireRequest> model);
        public HiringTableMatrixViewModel GetHiringTableMatrix();
        public void SaveHiringPricesDetails(HiringTableMatrixViewModel model);
        public void CompleteHireRequest(CompletedHireRequest model);


    }
}

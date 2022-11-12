using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;
using Transport.ViewModels;

namespace Transport.Repositories.IRepository
{
    public interface IHirerRepository
    {
        public void SetHirerDetails(HireDetailsViewModel model);
        public List<HirerHiringStatus> GetAllHireHiringStatus();
        public List<Hirer> GetAllHirers();
        public List<Hiring> AllHiring();
        public void ApprovedHire(ApproveHireRequest model, string Issuer);
        public void InvalidHire(ApproveHireRequest model, string Issuer);
        public void SetHirerHiringStatusToApproved(ApproveHireRequest hirer, string Issuer);
        public void CompleteHire(CompletedHireRequest model, string Issuer);
    }
}

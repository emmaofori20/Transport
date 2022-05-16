using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.Services.IServices
{
    public interface IInvoiceService
    {
        public void ApproveInvoice(int RequestId);
        public void InvalidInvoice(int RequestId);

        public void CompleteInvoice();

        public void UnApprovedInvoice(int RequestId);
    }
}

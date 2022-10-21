using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class RequestTypesViewModel
    {
        public List<RequestType> RequestTypes { get; set; }
        public RequestTypeNameAndChargeViewModel NewReqestTypeNameAndCharge { get; set; }
    }
    public class RequestTypeNameAndChargeViewModel
    {
        public int RequestTypeId { get; set; }
        public int RequestTypeChargeId { get; set; }
        [Required]
        public string RequestTypeName { get; set; }
        [Required]
        public string RequestTypeChargeName { get; set; }
        [Required]
        public decimal RequestTypeChargeValue { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.ViewModels
{
    public class AddUserViewModel
    {
        public int StaffId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string OtherName { get; set; }
        [Required]
        public string SurName { get; set; }
        public string CreatedBy { get; set; }
    }
}

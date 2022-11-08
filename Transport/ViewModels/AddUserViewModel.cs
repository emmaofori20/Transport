using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

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
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public SelectList AllRoles { get; set; }
    }
}

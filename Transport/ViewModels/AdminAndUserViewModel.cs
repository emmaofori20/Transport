using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Models.Data;

namespace Transport.ViewModels
{
    public class AdminAndUserViewModel : AddUserViewModel
    {
        public List<ApplicationUser> AllUsers { get; set; }
    }
}

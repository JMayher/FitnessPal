using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FitnessPal.Models.AccountViewModels
{
    public class AddUserViewModel
    {
        [Display(Name = "Username")]
        public String AccountUserName { get; set; }
    }
}

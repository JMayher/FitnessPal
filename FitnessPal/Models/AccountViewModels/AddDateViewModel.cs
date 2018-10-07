using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FitnessPal.Models.AccountViewModels
{
    public class AddDateViewModel
    {
        [Required]
        [Display(Name = "Date")]
        public String Edate { get; set; }
    }
}

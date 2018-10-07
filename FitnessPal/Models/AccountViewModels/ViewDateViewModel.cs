using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPal.Models.AccountViewModels
{
    public class ViewDateViewModel
    {
        public Date Date { get; set; }
        public IList<ExerciseUser> Things { get; set; }
    }
}

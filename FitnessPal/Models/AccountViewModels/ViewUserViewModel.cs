using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPal.Models.AccountViewModels
{
    public class ViewUserViewModel
    {
        public AccountUser AccountUser { get; set; }
        public IList<ExerciseUser> Things { get; set; }
    }
}


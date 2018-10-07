using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPal.Models
{
    public class ExerciseUser
    {
        public int ExerciseID { get; set; }
        public Exercise Exercise { get; set; }

        public int AccountUserID { get; set; }
        public AccountUser AccountUser { get; set; }

        public int DateID { get; set; }
        public Date Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPal.Models
{
    public class AccountUser
    {
        public int ID { get; set; }
        public String AccountUserName { get; set; }
        IList<ExerciseUser> ExerciseUsers = new List<ExerciseUser>();
    }
}

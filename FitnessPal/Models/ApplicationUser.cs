using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FitnessPal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public int ExerciseID { get; set; }
        //public Exercise Exercise { get; set; }
        IList<Exercise> Exercises { get; set; }
    }
}

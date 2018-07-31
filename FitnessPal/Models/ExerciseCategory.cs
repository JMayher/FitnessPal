using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPal.Models
{
    public class ExerciseCategory
    {
        public String Name { get; set; }
        public int ID { get; set; }
        public IList<Exercise> Exercises { get; set; }
    }
}

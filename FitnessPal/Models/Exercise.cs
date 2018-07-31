using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessPal.Models
{
    public class Exercise
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public ExerciseCategory Category { get; set; }
        public int ID { get; set; }
        public int CategoryID { get; set; }
        IList<ExerciseChoice> PlannedExercises = new List<ExerciseChoice>();
    }
}

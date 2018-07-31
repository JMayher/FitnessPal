using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessPal.Models;

namespace FitnessPal.Models.AccountViewModels
{
    public class AddExerciseViewModel
    {
        [Display(Name = "Exercise Name")]
        public string Name { get; set; }

        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Display(Name = "Exercise Type")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddExerciseViewModel(IEnumerable<ExerciseCategory> categories)
        {

            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }
        }
        
        public AddExerciseViewModel()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessPal.Models.AccountViewModels
{
    public class AddUserItemViewModel
    {
        public int ExerciseID { get; set; }
        public int AccountUserID { get; set; }
        public int DateID { get; set; }

        public AccountUser AccountUser { get; set; }
        public List<SelectListItem> Exercises { get; set; }
        public List<SelectListItem> Dates { get; set; }

        public AddUserItemViewModel() { }

        public AddUserItemViewModel(AccountUser accountUser, IEnumerable<Exercise> exercises, IEnumerable<Date> dates)
        {
            Exercises = new List<SelectListItem>();
            Dates = new List<SelectListItem>();

            foreach (var exercise in exercises)
            {
                Exercises.Add(new SelectListItem
                {
                    Value = exercise.ID.ToString(),
                    Text = exercise.Name

                });
            }

            foreach (var date in dates)
            {
                Dates.Add(new SelectListItem
                {
                    Value = date.ID.ToString(),
                    Text = date.Edate

                });
            }

            AccountUser = accountUser;
        }
    }
}
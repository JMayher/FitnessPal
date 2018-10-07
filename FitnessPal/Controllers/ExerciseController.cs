using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessPal.Models.AccountViewModels;
using FitnessPal.Data;
using Microsoft.EntityFrameworkCore;
using FitnessPal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FitnessPal.Controllers
{
    public class ExerciseController : Controller
    {
        private ApplicationDbContext context;

        public ExerciseController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
           
            {
                IList<Exercise> exercises = context.Exercises.Include(c => c.Category).ToList();
                ViewBag.title = "Home page for " + User.Identity.Name;
                return View(exercises);
            }
            
        }

        [Authorize]
        public IActionResult Add()
        {
            AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(context.Categories.ToList());
            return View(addExerciseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddExerciseViewModel addExerciseViewModel)
        {
            if (ModelState.IsValid)
            {
                var currentuser = HttpContext.User.Identity.Name;
               
                ExerciseCategory newExerciseCategory =
                    context.Categories.Single(c => c.ID == addExerciseViewModel.CategoryID);
                Exercise newExercise = new Exercise
                {
                    Name = addExerciseViewModel.Name,
                    Duration = addExerciseViewModel.Duration,
                    Category = newExerciseCategory
                };

                context.Exercises.Add(newExercise);
                context.SaveChanges();

                return Redirect("/Exercise");
            }
            return View(addExerciseViewModel);
        }
    }
}
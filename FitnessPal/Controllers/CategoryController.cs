using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessPal.Models.AccountViewModels;
using FitnessPal.Data;
using Microsoft.EntityFrameworkCore;
using FitnessPal.Models;

namespace FitnessPal.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext context;

        public CategoryController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<ExerciseCategory> categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                ExerciseCategory newCategory = new ExerciseCategory
                {
                    Name = addCategoryViewModel.Name,

                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessPal.Data;
using Microsoft.EntityFrameworkCore;
using FitnessPal.Models;
using FitnessPal.Models.AccountViewModels;


namespace FitnessPal.Controllers
{
    public class DateController : Controller
    {
        private ApplicationDbContext context;

        public DateController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Date> dates = context.Dates.ToList();

            return View(dates);
        }

        public IActionResult Add()
        {
            AddDateViewModel addDateViewModel = new AddDateViewModel();
            return View(addDateViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddDateViewModel addDateViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Date newDate = new Date
                {
                    Edate = addDateViewModel.Edate,

                };

                context.Dates.Add(newDate);
                context.SaveChanges();

                return Redirect("/Date");
            }

            return View(addDateViewModel);
        }

        public IActionResult ViewDate(int id)
        {
            int UserID = (int)TempData["UserID"];
            List<ExerciseUser> things = context
                .ExerciseUsers
                .Include(item => item.Exercise)
                .Where(cm => cm.DateID == id)
                .Include(item => item.AccountUser)
                .Where(cm => cm.AccountUserID == UserID)
                .ToList();

            Date date = context.Dates.Single(m => m.ID == id);

            ViewDateViewModel viewModel = new ViewDateViewModel
            {
                Date = date,
                Things = things
            };

            return View(viewModel);
        }
    }
}
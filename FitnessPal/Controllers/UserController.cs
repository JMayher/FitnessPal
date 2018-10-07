using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessPal.Models.AccountViewModels;
using FitnessPal.Data;
using Microsoft.EntityFrameworkCore;
using FitnessPal.Models;
using Microsoft.AspNetCore.Authorization;


namespace FitnessPal.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context;

        public UserController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<AccountUser> AccountUsers = context.AccountUsers.ToList();

            return View(AccountUsers);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AccountUser newUserName = new AccountUser
                {
                    AccountUserName = addUserViewModel.AccountUserName
                };
                context.AccountUsers.Add(newUserName);
                context.SaveChanges();

                return Redirect("/User/ViewUser/" + newUserName.ID);
            }
            return View(addUserViewModel);
        }

        public IActionResult ViewUser(int id)
        {
            List<ExerciseUser> things = context
                .ExerciseUsers
                .Include(item => item.Exercise)
                .Include(item => item.Date)
                .Where(cm => cm.AccountUserID == id)
                .ToList();

            AccountUser accountUser = context.AccountUsers.Single(m => m.ID == id);

            ViewUserViewModel viewModel = new ViewUserViewModel
            {
                AccountUser = accountUser,
                Things = things
            };

            TempData["UserID"] = viewModel.AccountUser.ID;
            TempData.Keep();

            return View(viewModel);
        }

        public IActionResult AddItem(int id)
        {
            AccountUser accountUser = context.AccountUsers.Single(m => m.ID == id);
            List<Exercise> exercises = context.Exercises.ToList();
            List<Date> dates = context.Dates.ToList();
            return View(new AddUserItemViewModel(accountUser, exercises, dates));
        }

        [HttpPost]
        public IActionResult AddItem(AddUserItemViewModel addUserItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var dateID = addUserItemViewModel.DateID;
                var exerciseID = addUserItemViewModel.ExerciseID;
                var accountUserID = addUserItemViewModel.AccountUserID;

                IList<ExerciseUser> existingItems = context.ExerciseUsers
                    .Where(cm => cm.ExerciseID == exerciseID)
                    .Where(cm => cm.DateID == dateID)
                    .Where(cm => cm.AccountUserID == accountUserID).ToList();

                if (existingItems.Count == 0)
                {
                    ExerciseUser userItem = new ExerciseUser
                    {
                        DateID = addUserItemViewModel.DateID,
                        ExerciseID = addUserItemViewModel.ExerciseID,
                        AccountUserID = addUserItemViewModel.AccountUserID
                    };

                    context.ExerciseUsers.Add(userItem);
                    context.SaveChanges();
                }
                return Redirect(string.Format("/User/ViewUser/{0}", addUserItemViewModel.AccountUserID));
            }

            return View(addUserItemViewModel);
        }
    }
}
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Helpers;
using System.Data.Entity.Migrations;

namespace StudentRegistrationSystem.Controllers.Admin
{
    public class ProfileController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();
        // GET: ManageAdminProfile
        public ActionResult Edit()
        {
            List<User> allUsers = studentHelper._dbContext.Users.ToList();
            List<User> onlyStudents = studentHelper.GetOnlyStudents();
            allUsers.RemoveAll(x => onlyStudents.Contains(x));
            User admin = allUsers[0];
            UpdateAdminViewModel updateAdminViewModel = new UpdateAdminViewModel
            {
                admin = admin,
                adminID = admin.UserID
            };
            return View(updateAdminViewModel);
        }
        [HttpPost]
        public ActionResult Edit(UpdateAdminViewModel updateAdminViewModel, int adminID)
        {
            User admin = studentHelper.FindUserByID(adminID);
            admin.Name = updateAdminViewModel.Name;
            admin.LastName = updateAdminViewModel.LastName;
            admin.Gender = updateAdminViewModel.Gender;
            admin.Phone = updateAdminViewModel.Phone;
            if (ModelState.IsValid)
            {
                TempData["AdminUpdateSuccess"] = "Not Null";
                studentHelper._dbContext.Users.AddOrUpdate<User>(admin);
                studentHelper._dbContext.SaveChanges();
                return RedirectToAction("Edit", "Profile");
            }
            else
            {
                return RedirectToAction("Admin", "Home");
            }
        }
        [HttpPost]
        public ActionResult UpdatePassword(UpdateAdminViewModel updateAdminViewModel, int adminID)
        {

            User admin = studentHelper.FindUserByID(adminID);
            string oldPassword = admin.Password;
            admin.Password = updateAdminViewModel.Password;
            if (updateAdminViewModel.oldPassword.Equals(oldPassword))
            {
                if (ModelState.IsValid)
                {
                    if (admin.Password.Equals(oldPassword))
                    {
                        TempData["SamePassword"] = "Not Null";
                        return RedirectToAction("Edit", "Profile");
                    }
                    else
                    {
                        TempData["PasswordSuccess"] = "Not Null";
                        studentHelper._dbContext.Users.AddOrUpdate<User>(admin);
                        studentHelper._dbContext.SaveChanges();
                        return RedirectToAction("Edit", "Profile");
                    }
                }
                else
                {
                    return RedirectToAction("Edit", "Profile");
                }
            }
            else
            {
                TempData["PasswordsDontMatch"] = "Not Null";
                return RedirectToAction("Edit", "Profile");
            }
        }
    }
}
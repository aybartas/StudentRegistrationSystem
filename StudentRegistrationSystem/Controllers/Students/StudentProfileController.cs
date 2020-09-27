using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers.Students
{
    public class StudentProfileController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();
        // GET: Profile
        public ActionResult Edit()
        {
            int UserID = int.Parse(User.Identity.Name.Split(',')[0]);
            User user = studentHelper._dbContext.Users.Find(UserID);
            UpdateStudentViewModel updateStudentViewModel = new UpdateStudentViewModel(user);
            return View(updateStudentViewModel);
        }
        [HttpPost]
        public ActionResult Edit(UpdateStudentViewModel updateStudentViewModel, int UserID)
        {
            User user = studentHelper.FindUserByID(UserID);
            user.Phone = updateStudentViewModel.Phone;
           
            if (ModelState.IsValid)
            {
                TempData["StudentUpdateSuccess"] = "Not Null";
                studentHelper._dbContext.Users.AddOrUpdate<User>(user);
                studentHelper._dbContext.SaveChanges();
                return RedirectToAction("Edit", "StudentProfile");
            }
            else
            {
                return RedirectToAction("Edit", "StudentProfile");
            }
        }
        [HttpPost]
        public ActionResult UpdatePassword(UpdateAdminViewModel updateAdminViewModel, int UserID)
        {

            User user = studentHelper.FindUserByID(UserID);
            string oldPassword = user.Password;
            user.Password = updateAdminViewModel.Password;
            if (updateAdminViewModel.oldPassword.Equals(oldPassword))
            {
                if (ModelState.IsValid)
                {
                    if (user.Password.Equals(oldPassword))
                    {
                        TempData["SamePassword"] = "Not Null";
                        return RedirectToAction("Edit", "StudentProfile");
                    }
                    else
                    {
                        TempData["PasswordSuccess"] = "Not Null";
                        studentHelper._dbContext.Users.AddOrUpdate<User>(user);
                        studentHelper._dbContext.SaveChanges();
                        return RedirectToAction("Edit", "StudentProfile");
                    }
                }
                else
                {
                    return RedirectToAction("Edit", "StudentProfile");
                }
            }
            else
            {
                TempData["PasswordsDontMatch"] = "Not Null";
                return RedirectToAction("Edit", "StudentProfile");
            }
        }
    }
}
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class UpdateAdminViewModel
    {
        public User admin { get; set; }
        public int adminID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string oldPassword { get; set; }
        public UpdateAdminViewModel()
        {

        }
    }
}
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.ViewModels
{
    public class AddStudentViewModel
    {
        public User user { get; set; }        
        public List<Department> departments { get; set; }

        public SelectList lecturers { get; set; }

        public AddStudentViewModel(List<Department> departments)
        {
            user = new User();
            this.departments = departments;
           
        }

        public AddStudentViewModel()
        {
        }
    }
}
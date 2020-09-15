using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class AddStudentViewModel
    {
        public User user { get; set; }
        public List<Department> departments { get; set; }

        public List<Lecturer> lecturers { get; set; }

        public AddStudentViewModel(List<Department> departments, List<Lecturer> lecturers)
        {
            user = new User();
            this.departments = departments;
            this.lecturers = lecturers;
        }
    }
}
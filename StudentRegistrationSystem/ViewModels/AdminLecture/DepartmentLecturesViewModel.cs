using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels.AdminLecture
{
    public class DepartmentLecturesViewModel
    {

        public Department department { get; set; }
        public List<Lecture> lectures { get; set; }

        public DepartmentLecturesViewModel(Department department, List<Lecture> lectures)
        {
            this.department = department;
            this.lectures = lectures;
        }
    }
}
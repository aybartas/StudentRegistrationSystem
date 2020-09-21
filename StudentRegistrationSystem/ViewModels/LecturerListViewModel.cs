using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class LecturerListViewModel
    {
        public LecturerListViewModel()
        {
        }
        public Lecturer lecturer { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DepartmentCode { get; set; }
        public List<Lecturer> lecturerlist { get; set; }
        public Department department { get; set; }
        public List<Department> departmentList { get; set; }
    }
}
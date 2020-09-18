using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class UpdateStudentViewModel
    {
        public User user { get; set; }
        public int userID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string EducationType { get; set; }
        public string Password { get; set; }
        public int LecturerID { get; set; }
        public List<Lecturer> departmentLecturers { get; set; }
        public UpdateStudentViewModel()
        {
        }
        public UpdateStudentViewModel(User userp, List<Lecturer> lecturers)
        {
            user = userp;
            departmentLecturers = lecturers;
        }

        
    }
}
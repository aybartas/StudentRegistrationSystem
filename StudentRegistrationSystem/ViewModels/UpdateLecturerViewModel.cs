using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class UpdateLecturerViewModel
    {
        public Lecturer lecturer { get; set; }
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email alanının girilmesi zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz email adresi")]
        public string Email { get; set; }
        public string DepartmentCode { get; set; }
        public List<Department> departmentList { get; set; }
        public List<Section> sectionsGiven { get; set; }
        public List<Lecture> allDepartmentalLectures { get; set; }
        public string educationType { get; set; }
        public int LectureID { get; set; }
        public string LectureCode { get; set; }
        public UpdateLecturerViewModel()
        {
        }
    }
}
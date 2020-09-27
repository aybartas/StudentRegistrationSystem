using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels.AdminLecture
{
    public class AddLectureViewModel
    {
        public string LectureCode { get; set; }
        public string Name { get; set; }
        public string EducationType { get; set; }
        public int Credit { get; set; }
        public string Term { get; set; }

        public string DepartmentCode { get; set; }

        public Department department { get; set; }

        public List<Lecturer> lecturers { get; set; }

        public AddLectureViewModel(string lectureCode, string name, string educationType, int credit, string term, string departmentCode)
        {
            LectureCode = lectureCode;
            Name = name;
            EducationType = educationType;
            Credit = credit;
            Term = term;
            DepartmentCode = departmentCode;
        }

        public AddLectureViewModel(string lectureCode, string name, string educationType, int credit, string term, string departmentCode, Department department, List<Lecturer> lecturers) : this(lectureCode, name, educationType, credit, term, departmentCode)
        {
            this.department = department;
            this.lecturers = lecturers;
        }

        public AddLectureViewModel()
        {
        }

    }

}
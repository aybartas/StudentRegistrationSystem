using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels.AdminLecture
{
    public class UpdateLectureFormViewModel
    {
        public string LectureCode { get; set; }
        public string Name { get; set; }
        public string EducationType { get; set; }
        public int Credit { get; set; }
        public string Term { get; set; }

        public UpdateLectureFormViewModel(string lectureCode, string name, string educationType, int credit, string term)
        {
            LectureCode = lectureCode;
            Name = name;
            EducationType = educationType;
            Credit = credit;
            Term = term;
        }

        public UpdateLectureFormViewModel()
        {
        }
    }
}
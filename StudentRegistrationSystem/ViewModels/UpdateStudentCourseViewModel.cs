using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class UpdateStudentCourseViewModel
    {
        public User user { get; set; }
        public List<Section> sections { get; set; }
        public int sectionNumber { get; set; }
        public int LectureID { get; set; }
        public List<Lecture> departmentalLectures { get; set; }
    

    public UpdateStudentCourseViewModel()
        {
        }
    }
}
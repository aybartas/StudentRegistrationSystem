using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class SearchLectureViewModel
    {
        public List<Lecture> lectures { get; set; }

        public SearchLectureViewModel(List<Lecture> lectures)
        {
            this.lectures = lectures;
        }

        public SearchLectureViewModel()
        {
        }
    }
}
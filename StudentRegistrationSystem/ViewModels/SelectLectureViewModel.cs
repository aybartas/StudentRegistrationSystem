using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class SelectLectureViewModel
    {
        public List<Lecture> lectures { get; set; }
        public List<Enrollment> currentlySelectedSections { get; set; }

        public SelectLectureViewModel(List<Lecture> lectures, List<Enrollment> currentlySelectedSections)
        {
            this.lectures = lectures;
            this.currentlySelectedSections = currentlySelectedSections;
        }

        public SelectLectureViewModel()
        {
        }
    }
}
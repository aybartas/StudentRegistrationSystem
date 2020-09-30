using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class TranscriptViewModel
    {


        public List<Enrollment> enrollments { get; set; }

        public double cgpa { get; set; }

        public TranscriptViewModel(List<Enrollment> enrollments,double cgpa)
        {
            this.enrollments = enrollments;
            this.cgpa = cgpa; 
        }

        public TranscriptViewModel()
        {
        }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models.Entity
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int SectionID { get; set; }
        public int UserID { get; set; }
        public string Grade { get; set; }
        public virtual User Student { get; set; }
        public virtual Section Section { get; set; }

    }
}
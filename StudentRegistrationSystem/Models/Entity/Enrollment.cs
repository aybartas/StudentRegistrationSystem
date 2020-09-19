using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models.Entity
{
    public class Enrollment
    {

        public int EnrollmentID { get; set; }
#nullable enable
        public string? Grade { get; set; }
#nullable disable

        public int UserID { get; set; }

        public int SectionID { get; set; }

        public User User { get; set; }

        public Section Section { get; set; }



    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID { get; set; }
        public int SectionID { get; set; }
        public int StudentID { get; set; }
        public string Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Section Section { get; set; }

    }
}
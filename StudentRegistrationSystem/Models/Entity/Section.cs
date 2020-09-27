using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;

namespace StudentRegistrationSystem.Models.Entity
{
    public class Section
    {
        public int SectionID { get; set; }
        public int Number { get; set; }

        public string Time { get; set; }
        public string EndTime { get; set; }
        public string Day { get; set; }
        public int Quota { get; set; }
        public string Building { get; set; }
        public string Classroom { get; set; }


        public int LecturerID { get; set; }
        public Lecturer Lecturer { get; set; }
        
        public int LectureID { get; set; }
        public Lecture Lecture { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        

    }
}
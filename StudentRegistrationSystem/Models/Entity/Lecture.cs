using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
    public class Lecture
    {
        public int LectureID { get; set; }
        public string LectureCode { get; set; }
        public string Name { get; set; }
        public string EducationType { get; set; }
        public int Credit { get; set; }
        public string Term { get; set; }

        public string DepartmentCode { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<Section> Sections { get; set; }

    }
}
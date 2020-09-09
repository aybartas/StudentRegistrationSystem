using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models.Entity
{
    public class Lecturer
    {
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DepartmentCode { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<Student> ConsultedStudents { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
       







    }
}
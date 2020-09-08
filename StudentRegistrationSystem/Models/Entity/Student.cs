using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
    public class Student
    {
       //[Key]
      // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long CitizenshipNo { get; set; }
        public string Gender { get; set; }

        public string Phone { get; set; }
        public string EducationType { get; set; }
        public string Password { get; set; }

        public string DepartmentCode { get; set; }

        public int LecturerID { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Department Department { get; set; }
        public Lecturer Lecturer { get; set; }

          
    }
}
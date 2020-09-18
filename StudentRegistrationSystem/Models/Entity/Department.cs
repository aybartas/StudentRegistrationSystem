using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models.Entity

{
    public class Department
    {
        [Key]
        public string DepartmentCode { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Lecturer> Lecturers { get; set; }

        public virtual IEnumerable<Lecture> Lectures { get; set; }


    }
}
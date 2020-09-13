﻿using System;
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

        public virtual ICollection<User> Students { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }


    }
}
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
#nullable enable
        public string? DepartmentCode { get; set; }
#nullable disable
        public Department Department { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<Section> Sections { get; set; }
       







    }
}
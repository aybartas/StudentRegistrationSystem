using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class StudentRecordViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }

        public string Lastname { get; set; }
        public string EducationType { get; set; }

        public string Department { get; set; }

        public string Advisor { get; set; }

        public StudentRecordViewModel(int UserID,string Name, string Lastname, string EducationType,string Department,string Advisor)
        {
            this.UserID = UserID;
            this.Name = Name;
            this.Lastname = Lastname;
            this.EducationType = EducationType;
            this.Department = Department;
            this.Advisor = Advisor;
        }

    }
}
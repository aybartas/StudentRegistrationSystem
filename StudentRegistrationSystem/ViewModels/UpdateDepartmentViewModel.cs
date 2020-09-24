using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class UpdateDepartmentViewModel
    {
       public string DepartmentCode { get; set; }
       public Department Department { get; set; }
       public string Name { get; set; }
       public string Phone { get; set; }
       public string OldDepartmentCode { get; set; }

        public UpdateDepartmentViewModel()
        {
        }
    }
}
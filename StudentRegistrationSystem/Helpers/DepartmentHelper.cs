using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class DepartmentHelper:EntityHelper
    {
        

        public DepartmentHelper()
        {
        }

        public List<Department> GetDepartments()
        {
            return _dbContext.Departments.ToList();
        }
        public void AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            
        }
        public string DepNameFinder(string DepartmentCode)
        {
            Department dep = _dbContext.Departments.Find(DepartmentCode);
            if (dep != null)
            {
                return dep.Name;
            }
            else
            {
                return null;
            }
        }


    }
}
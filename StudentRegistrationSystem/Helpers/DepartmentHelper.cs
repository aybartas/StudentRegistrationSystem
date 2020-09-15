using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class DepartmentHelper
    {
        readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();
        public List<Department> GetDepartments()
        {
            return _dbContext.Departments.ToList();
        }
        public string AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return department.DepartmentCode;
        }
        public string DepNameFinder(string DepartmentCode)
        {
            Department dep = _dbContext.Departments.Find(DepartmentCode);
            return dep.Name;
        }
    }
}
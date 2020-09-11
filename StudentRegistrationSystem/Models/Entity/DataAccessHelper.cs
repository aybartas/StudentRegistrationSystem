using StudentRegistrationSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StudentRegistrationSystem.Models.Entity
{
    public class DataAccessHelper
    {
        readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();

        public List<Enrollment> GetEnrollments(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            List <Enrollment> enrollments = user.Enrollments.Cast<Enrollment>().ToList();
           
            return enrollments;
        }
        public List<User> FetchUsers()
        {
            return _dbContext.Users.ToList();
        }

        public List<Department> FetchDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public int AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.UserID;
        }

        public string AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return department.DepartmentCode;
        }
    }
}
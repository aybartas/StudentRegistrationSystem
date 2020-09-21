using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class EnrollmentHelper
    {
        public StudentRegistrationContext  _dbContext { get; set; }

        public EnrollmentHelper()
        {
            _dbContext = new StudentRegistrationContext();
        }

        public List<Enrollment> GetEnrollments()
        {
            return _dbContext.Enrollments.ToList();
        }
        public void AddEnrollment(Enrollment enrollment)
        {
            _dbContext.Enrollments.Add(enrollment);
            _dbContext.SaveChanges();

        }
        
        public void DeleteEnrollment(int UserID , int SectionID)
        {
            Enrollment enrollment = _dbContext.Enrollments.FirstOrDefault(m => m.UserID == UserID && m.SectionID == SectionID);
            _dbContext.Enrollments.Remove(enrollment);
            _dbContext.SaveChanges();
        }

        public Enrollment GetEnrollment(int UserID, int SectionID)
        {
            
            return  _dbContext.Enrollments.FirstOrDefault(m => m.UserID == UserID && m.SectionID == SectionID);
        }





    }
}
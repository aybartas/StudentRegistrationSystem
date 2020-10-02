using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class EnrollmentHelper:EntityHelper
    {

        public EnrollmentHelper()
        {
        }

        public List<Enrollment> GetEnrollments()
        {
            return _dbContext.Enrollments.ToList();
        }
        public double calculateCGPA(List<Enrollment> enrollments)
        {
            var gradeList = new Dictionary<string, double> {
            { "A",4},
            { "B",3.5},
            {"C",3},
            {"D",2.5},
            {"E",2 },
            {"F",0}};

            int totalCredit = 0;
            double totalCreditMultiplyGrade = 0;
            foreach (Enrollment e in enrollments)
            {
                if(e.Grade != null)
                {
                    totalCredit += e.Section.Lecture.Credit;

                    try
                    {
                        totalCreditMultiplyGrade += (e.Section.Lecture.Credit) * (gradeList[e.Grade]);
                    }
                    catch
                    {

                    }
        
                }
            }

            return (((double)totalCreditMultiplyGrade)/totalCredit);
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
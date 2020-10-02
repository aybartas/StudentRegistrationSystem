using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class StudentHelper:EntityHelper
    {
        public LectureHelper lectureHelper { get; set; }
        //readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();

        public StudentHelper()
        {
            lectureHelper = new LectureHelper();
        }

        public List<User> GetOnlyStudents()
        {
            
            List<User> students = _dbContext.Users.Where(m => m.Role.Equals("U")).ToList();
            
            return students;
        }
        public List<Section> GetSyllabusSec(int UserID)
        {

            List<Enrollment> enrollment = GetEnrollments(UserID);
            List<Section> sections = new List<Section>();
            foreach (Enrollment x in enrollment)
            {
                if (x.Grade == null)
                {
                    sections.Add(_dbContext.Sections.Find(x.SectionID));
                }
            }
            return sections;
        }
       
       

        public Lecturer GetAdvisor(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            int? lecID = user.LecturerID;
            Lecturer lecturer = _dbContext.Lecturers.Find(lecID);
            return lecturer;
        }

        // get all lectures from department of the user
        public List<Lecture> GetAllLecturesOfUsersDepartment(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            List<Lecture> lectures = _dbContext.Lectures.ToList();
            List<Lecture> rlectures = new List<Lecture>();
            foreach (Lecture l in lectures)
            {
                if (l.DepartmentCode == user.DepartmentCode)
                {
                    rlectures.Add(l);
                }
            }
            return rlectures;
        }
        // get all lectures from department of the user depending on user's education type
        public List<Lecture> GetAllLecturesOfUsersDepartmentDependingOnEducationType(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            List<Lecture> lectures = _dbContext.Lectures.ToList();
            List<Lecture> rlectures = new List<Lecture>();
            foreach (Lecture l in lectures)
            {
                if (l.DepartmentCode == user.DepartmentCode && l.EducationType == user.EducationType)
                {
                    rlectures.Add(l);
                }
            }
            return rlectures;
        }
        public User FindUserByID(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            return user;
        }

        // get previous lectures of student
        public List<Lecture> GetTranscript(int UserID)
        {
            List<Enrollment> enrollment = GetEnrollments(UserID);
            List<Section> sections = new List<Section>();
            foreach (Enrollment x in enrollment)
            {
                if (x.Grade != null)
                {
                    sections.Add(_dbContext.Sections.Find(x.SectionID));
                }
            }
            List<Lecture> lectures = lectureHelper.GetLecturesOfSections(sections);
            return lectures;
        }


        // get current lectures of given student
         public List<Lecture> GetSyllabus(int UserID)
        {
            List<Enrollment> enrollment = GetEnrollments(UserID);
            List<Section> sections = new List<Section>();
            foreach (Enrollment x in enrollment)
            {
                if (x.Grade == null)
                {
                    sections.Add(_dbContext.Sections.Find(x.SectionID));
                }
            }
            List<Lecture> lectures = lectureHelper.GetLecturesOfSections(sections);
            return lectures;
        }
        
        public List<Enrollment> GetEnrollments(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            List<Enrollment> enrollments = user.Enrollments.Cast<Enrollment>().ToList();

            return enrollments;
        }

     
    }
}
using StudentRegistrationSystem.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace StudentRegistrationSystem.Models.Entity
{
    public class DataAccessHelper
    {
        readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();


        public List<Lecture> GetTranscript(int UserID)
        {
            List<Enrollment> enrollment = GetEnrollments(UserID);
            List<Section> sections = new List<Section>();
            foreach(Enrollment x in enrollment)
            {
                if (x.Grade != null)
                {
                   sections.Add(_dbContext.Sections.Find(x.SectionID));
                }
            }
            List<Lecture> lectures = GetLecture(sections);
            return lectures;
        }
        public List<Lecture> Syllabus(int UserID)
        {
            List<Enrollment> enrollment = GetEnrollments(UserID);
            List<Section> sections = new List<Section>();
            foreach(Enrollment x in enrollment)
            {
                if(x.Grade == null)
                {
                    sections.Add(_dbContext.Sections.Find(x.SectionID));
                }
            }
            List<Lecture> lectures = GetLecture(sections);
            return lectures;
        }
        public List<Enrollment> GetEnrollments(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            List <Enrollment> enrollments = user.Enrollments.Cast<Enrollment>().ToList();
           
            return enrollments;
        }
        public List<Lecture> GetLecture()
        {
            return _dbContext.Lectures.ToList();
        }
        public List<Lecture> GetLecture(List<Section> sections)
        {
            List<Lecture> lectures = new List<Lecture>();
            foreach (Section x in sections)
            {
                lectures.Add(_dbContext.Lectures.Find(x.LectureID));
            }
            return lectures;
        }
        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public List<Department> GetDepartments()
        {
            return _dbContext.Departments.ToList();
        }
        public List<Lecturer> GetLecturer()
        {
            return _dbContext.Lecturers.ToList();
        }
        public List<Section> GetSection()
        {
            return _dbContext.Sections.ToList();
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

        public int AddSection(Section section)
        {
            _dbContext.Sections.Add(section);
            _dbContext.SaveChanges();
            return section.SectionID;
        }

        public int AddLecture(Lecture lecture)
        {
            _dbContext.Lectures.Add(lecture);
            _dbContext.SaveChanges();
            return lecture.LectureID;
        }

        public int AddLecturer(Lecturer lecturer)
        {
            _dbContext.Lecturers.Add(lecturer);
            _dbContext.SaveChanges();
            return lecturer.LecturerID;
        }

        
    }
}
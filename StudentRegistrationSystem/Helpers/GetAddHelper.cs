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
    public class GetAddHelper
    {
        readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();

        
        public List<Lecture> GetLecture()
        {
            return _dbContext.Lectures.ToList();
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
        //public Lecturer GetAdvisor(int UserID)
        //{
        //    User user = _dbContext.Users.Find(UserID);
        //    int lecID = user.LecturerID;
        //    Lecturer lecturer = _dbContext.Lecturers.Find(lecID);
        //    return lecturer;
        //}
        //public List<Lecture> GetDeptAll(int UserID)
        //{
        //    User user = _dbContext.Users.Find(UserID);
        //    List<Lecture> lectures = GetLecture();
        //    List<Lecture> rlectures = new List<Lecture>();
        //    foreach (Lecture l in lectures)
        //    {
        //        if (l.DepartmentCode == user.DepartmentCode)
        //        {
        //            rlectures.Add(l);
        //        }
        //    }
        //    return rlectures;
        //}
        //public User FindUserByID(int UserID)
        //{
        //    User user = _dbContext.Users.Find(UserID);
        //    return user;
        //}
        //public List<Lecture> GetTranscript(int UserID)
        //{
        //    List<Enrollment> enrollment = GetEnrollments(UserID);
        //    List<Section> sections = new List<Section>();
        //    foreach (Enrollment x in enrollment)
        //    {
        //        if (x.Grade != null)
        //        {
        //            sections.Add(_dbContext.Sections.Find(x.SectionID));
        //        }
        //    }
        //    List<Lecture> lectures = GetLecture(sections);
        //    return lectures;
        //}
        //public List<Lecture> GetSyllabus(int UserID)
        //{
        //    List<Enrollment> enrollment = GetEnrollments(UserID);
        //    List<Section> sections = new List<Section>();
        //    foreach (Enrollment x in enrollment)
        //    {
        //        if (x.Grade == null)
        //        {
        //            sections.Add(_dbContext.Sections.Find(x.SectionID));
        //        }
        //    }
        //    List<Lecture> lectures = GetLecture(sections);
        //    return lectures;
        //}
        //public List<Section> GetSyllabusSec(int UserID)
        //{
        //    List<Enrollment> enrollment = GetEnrollments(UserID);
        //    List<Section> sections = new List<Section>();
        //    foreach (Enrollment x in enrollment)
        //    {
        //        if (x.Grade == null)
        //        {
        //            sections.Add(_dbContext.Sections.Find(x.SectionID));
        //        }
        //    }
        //    return sections;
        //}
        //public List<Enrollment> GetEnrollments(int UserID)
        //{
        //    User user = _dbContext.Users.Find(UserID);
        //    List<Enrollment> enrollments = user.Enrollments.Cast<Enrollment>().ToList();

        //    return enrollments;
        //}
        //public List<Section> GetSectionsOfLecture(int LectureID)
        //{
        //    List<Section> sections = new List<Section>();
        //    List<Section> allsections = GetSection();
        //    foreach (Section s in allsections)
        //    {
        //        if (s.LectureID == LectureID)
        //        {
        //            sections.Add(s);
        //        }
        //    }
        //    return sections;
        //}
        //public Lecturer LecturerFinderBySection(int SectionID)
        //{
        //    Section section = _dbContext.Sections.Find(SectionID);
        //    Lecturer lecturer = _dbContext.Lecturers.Find(section.LecturerID);
        //    return lecturer;
        //}
    }
}
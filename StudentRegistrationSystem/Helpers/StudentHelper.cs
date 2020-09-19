using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class StudentHelper
    {
        public LectureHelper lectureHelper { get; set; }
        //readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();
        public  StudentRegistrationContext _dbContext  { get; set; }

        public StudentHelper()
        {
            lectureHelper = new LectureHelper();
            _dbContext = new StudentRegistrationContext();
        }

        public List<User> GetOnlyStudents()
        {
            List<User> students = new List<User>();
            List<User> all = GetUsers();
            foreach(User u in all)
            {
                if (u.Role.Equals("U"))
                {
                    students.Add(u);
                }
            }
            return students;
        }
        public List<Section> GetSyllabusSec(int UserID)
        {
            var record = _dbContext..Find(Id, InstanceId).ToList();
            User user = _dbContext.Users.Find(UserID);
            user.
            //List<Enrollment> enrollment = GetEnrollments(UserID);
            //List<Section> sections = new List<Section>();
            //foreach (Enrollment x in enrollment)
            //{
            //    if (x.Grade == null)
            //    {
            //        sections.Add(_dbContext.Sections.Find(x.SectionID));
            //    }
            //}
            //return sections;
        }
        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
        public int AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.UserID;
        }
        public Lecturer GetAdvisor(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            int lecID = user.LecturerID;
            Lecturer lecturer = _dbContext.Lecturers.Find(lecID);
            return lecturer;
        }
        public List<Lecture> GetDeptAll(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            List<Lecture> lectures = lectureHelper.GetLecture();
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
        public User FindUserByID(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            return user;
        }

        /*
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
        

        */

        /*
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

        public List<Enrollment> GetEnrollments(int UserID)
        {
            User user = _dbContext.Users.Find(UserID);
            List<Enrollment> enrollments = user.Enrollments.Cast<Enrollment>().ToList();

            return enrollments;
        }

     */
    }
}
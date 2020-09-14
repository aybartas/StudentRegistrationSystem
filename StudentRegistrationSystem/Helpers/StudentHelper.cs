using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem
{
    public class StudentHelper
    {
        LectureHelper lectureHelper = new LectureHelper();
        GetAddHelper getAddHelper = new GetAddHelper();
        readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();

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
            List<Lecture> lectures = getAddHelper.GetLecture();
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
    }
}
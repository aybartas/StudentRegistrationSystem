using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class LecturerHelper
    {
        //readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();
        public  StudentRegistrationContext _dbContext { get; set; }

        public LecturerHelper()
        {
            _dbContext = new StudentRegistrationContext();
        }

        public List<Lecturer> GetLecturers()
        {
            return _dbContext.Lecturers.ToList();
        }
        public void AddLecturer(Lecturer lecturer)
        {
            _dbContext.Lecturers.Add(lecturer);
            _dbContext.SaveChanges();
          
        }
        public Lecturer LecturerFinderBySection(int SectionID)
        {
            Section section = _dbContext.Sections.Find(SectionID);
            Lecturer lecturer = _dbContext.Lecturers.Find(section.LecturerID);
            return lecturer;
        }
        public List<Lecture> GetAllLecturesOfLecturersDepartment(int LecturerID)
        {
            Lecturer lecturer = _dbContext.Lecturers.Find(LecturerID);
            List<Lecture> lectures = _dbContext.Lectures.ToList();
            List<Lecture> rlectures = new List<Lecture>();
            foreach (Lecture l in lectures)
            {
                if (l.DepartmentCode == lecturer.DepartmentCode)
                {
                    rlectures.Add(l);
                }
            }
            return rlectures;
        }
    }
}
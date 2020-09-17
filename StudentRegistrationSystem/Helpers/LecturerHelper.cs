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

        public List<Lecturer> GetLecturer()
        {
            return _dbContext.Lecturers.ToList();
        }
        public int AddLecturer(Lecturer lecturer)
        {
            _dbContext.Lecturers.Add(lecturer);
            _dbContext.SaveChanges();
            return lecturer.LecturerID;
        }
        public Lecturer LecturerFinderBySection(int SectionID)
        {
            Section section = _dbContext.Sections.Find(SectionID);
            Lecturer lecturer = _dbContext.Lecturers.Find(section.LecturerID);
            return lecturer;
        }
    }
}
using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class LectureHelper
    {
        //readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();
        public StudentRegistrationContext _dbContext { get; set; }

        public LectureHelper()
        {
            _dbContext = new StudentRegistrationContext();
        }

        public void AddLecture(Lecture lecture)
        {
            _dbContext.Lectures.Add(lecture);
            _dbContext.SaveChanges();

        }

        public List<Lecture> GetLecturesOfSections(List<Section> sections)
        {
            List<Lecture> lectures = new List<Lecture>();

            foreach (Section x in sections)
            {
                lectures.Add(_dbContext.Lectures.Find(x.LectureID));
            }
            return lectures;
        }
        public List<Lecture> GetLectures()
        {
            return _dbContext.Lectures.ToList();
        }

    }
}
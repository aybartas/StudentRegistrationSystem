using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class LectureHelper:EntityHelper
    {
        //readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();

        public LectureHelper()
        {
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
        public List<Lecture> lecturesToShowInSelectLecture(List<Lecture> allLectures,List<Enrollment> usersEnrollments)
        {          
            foreach(Enrollment e in usersEnrollments)
            {
                if(e.Grade != null && (e.Grade.Equals("A") || e.Grade.Equals("B") || e.Grade.Equals("C") || e.Grade.Equals("D") || e.Grade.Equals("E")))
                {
                    //Lecture lecture = _dbContext.Lectures.Find(e.Section.LectureID);
                    allLectures.Remove(allLectures.FirstOrDefault(l => l.LectureID == e.Section.LectureID));          
                }
            }
            return allLectures;
        }



    }
}
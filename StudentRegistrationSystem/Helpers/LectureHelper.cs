using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem
{
    public class LectureHelper
    {
        GetAddHelper GetAddHelper = new GetAddHelper();
        readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();
        public List<Lecture> GetLecturesOfSections(List<Section> sections)
        {
            List<Lecture> lectures = new List<Lecture>();
            foreach (Section x in sections)
            {
                lectures.Add(_dbContext.Lectures.Find(x.LectureID));
            }
            return lectures;
        }
        public List<Section> GetSectionsOfLecture(int LectureID)
        {
            List<Section> sections = new List<Section>();
            List<Section> allsections = GetAddHelper.GetSection();
            foreach (Section s in allsections)
            {
                if (s.LectureID == LectureID)
                {
                    sections.Add(s);
                }
            }
            return sections;
        }
        public Lecturer LecturerFinderBySection(int SectionID)
        {
            Section section = _dbContext.Sections.Find(SectionID);
            Lecturer lecturer = _dbContext.Lecturers.Find(section.LecturerID);
            return lecturer;
        }
    }
}
using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class SectionHelper
    {
        //readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();
        public StudentRegistrationContext _dbContext { get; set; }

        public SectionHelper()
        {
            _dbContext = new StudentRegistrationContext();
        }

        public List<Section> GetAllSections()
        {
            return _dbContext.Sections.ToList();
        }
        public void AddSection(Section section)
        {
            _dbContext.Sections.Add(section);
            _dbContext.SaveChanges();
            
        }
        public List<Section> GetSectionsOfLecture(int LectureID)
        {
            List<Section> sections = new List<Section>();
            List<Section> allsections = GetAllSections();
            foreach (Section s in allsections)
            {
                if (s.LectureID == LectureID)
                {
                    sections.Add(s);
                }
            }
            return sections;
        }

       
        public List<Section> GetSectionsOfEnrollemnts(List<Enrollment> enrollments)
        {
            List<Section> sections = new List<Section>();
            foreach(Enrollment enrollment in enrollments)
            {
                Section section = _dbContext.Sections.Find(enrollment.SectionID);
                sections.Add(section);
            }
            return sections;
        }
     
    }
}
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
        public List<Section> GetSection()
        {
            return _dbContext.Sections.ToList();
        }
        public int AddSection(Section section)
        {
            _dbContext.Sections.Add(section);
            _dbContext.SaveChanges();
            return section.SectionID;
        }
        public List<Section> GetSectionsOfLecture(int LectureID)
        {
            List<Section> sections = new List<Section>();
            List<Section> allsections = GetSection();
            foreach (Section s in allsections)
            {
                if (s.LectureID == LectureID)
                {
                    sections.Add(s);
                }
            }
            return sections;
        }
    }
}
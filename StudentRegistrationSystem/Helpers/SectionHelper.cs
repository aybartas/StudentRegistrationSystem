using StudentRegistrationSystem.Models.Context;
using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Helpers
{
    public class SectionHelper:EntityHelper
    {
        //readonly StudentRegistrationContext _dbContext = new StudentRegistrationContext();

        public SectionHelper()
        {
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

       
        public List<Section> GetSectionsOfEnrollments(List<Enrollment> enrollments)
        {
            List<Section> sections = new List<Section>();
            foreach(Enrollment enrollment in enrollments)
            {
                Section section = _dbContext.Sections.Find(enrollment.SectionID);
                sections.Add(section);
            }
            return sections;
        }
        public int dayToInt(Section section)
        {
            if (section.Day.Equals("Pazartesi")) { return 0; }
            if (section.Day.Equals("Salı")) { return 1; }
            if (section.Day.Equals("Çarşamba")) { return 2; }
            if (section.Day.Equals("Perşembe")) { return 3; }
            if (section.Day.Equals("Cuma")) { return 4; }
            else { return -1; }
        }
        public Boolean isThereASection (Section section, double duo)
        {
            double startTime = Convert.ToDouble(section.Time.Replace(".", ","));
            double endTime = Convert.ToDouble(section.EndTime.Replace(".", ","));
            if (startTime <= duo && duo < endTime)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
     
    }
}
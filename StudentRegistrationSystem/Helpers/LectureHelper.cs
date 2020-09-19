﻿using StudentRegistrationSystem.Models.Context;
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
        //public List<Lecture> GetLecture()
        //{
        //    List<User> user = _dbContext.Users.
        //    return _dbContext.Lectures.ToList();
        //}
        public int AddLecture(Lecture lecture)
        {
            _dbContext.Lectures.Add(lecture);
            _dbContext.SaveChanges();
            return lecture.LectureID;
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
    }
}
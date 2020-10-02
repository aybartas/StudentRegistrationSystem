using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class TimeTableViewModel
    {
        public Section section { get; set; }
        public int dayDecider { get; set; }
        public double startTime { get; set; }
        public TimeTableViewModel(Section section, int day, double time)
        {
            this.section = section;
            this.dayDecider = day;
            this.startTime = time;
        }

        public TimeTableViewModel()
        {
        }
    }
}
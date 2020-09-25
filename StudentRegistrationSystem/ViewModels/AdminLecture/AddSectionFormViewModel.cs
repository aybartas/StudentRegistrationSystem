using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels.AdminLecture
{
    public class AddSectionFormViewModel
    {

        public int Number { get; set; }
        public string Time { get; set; }
        public string EndTime { get; set; }
        public string Day { get; set; }
        public int Quota { get; set; }
        public string Building { get; set; }
        public string Classroom { get; set; }

        public int LecturerID { get; set; }

        public AddSectionFormViewModel(int number, string time, string endTime, string day, int quota, string building, string classroom, int lecturerID)
        {
            Number = number;
            Time = time;
            EndTime = endTime;
            Day = day;
            Quota = quota;
            Building = building;
            Classroom = classroom;
            LecturerID = lecturerID;
        }

        public AddSectionFormViewModel()
        {
        }
    }
}
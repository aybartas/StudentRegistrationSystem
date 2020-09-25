using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels.AdminLecture
{
    public class UpdateSectionFormViewModel
    {
        public int Number { get; set; }
        public string Time { get; set; }
        public string EndTime { get; set; }
        public string Day { get; set; }
        public int Quota { get; set; }
        public string Building { get; set; }
        public string Classroom { get; set; }

        public int LecturerID { get; set; }

        public UpdateSectionFormViewModel()
        {
        }
    }
}
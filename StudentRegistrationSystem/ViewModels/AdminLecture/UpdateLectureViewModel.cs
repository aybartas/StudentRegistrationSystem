using StudentRegistrationSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels.AdminLecture
{
    public class UpdateLectureViewModel
    {
       
        public Lecture lecture { get; set; }
        public List<Section> sections { get; set; }

        public string departmentName { get; set; }

        public UpdateLectureFormViewModel updateLectureFormViewModel { get; set; }

        public AddSectionFormViewModel addSectionFormViewModel { get; set; }

        public UpdateSectionFormViewModel updateSectionFormViewModel { get; set; }

        

        public UpdateLectureViewModel(Lecture lecture, List<Section> sections, string departmentName, UpdateLectureFormViewModel updateLectureFormViewModel, AddSectionFormViewModel addSectionFormViewModel, UpdateSectionFormViewModel updateSectionFormViewModel)
        {
            this.lecture = lecture;
            this.sections = sections;
            this.departmentName = departmentName;
            this.updateLectureFormViewModel = updateLectureFormViewModel;
            this.addSectionFormViewModel = addSectionFormViewModel;
            this.updateSectionFormViewModel = updateSectionFormViewModel;
        }
    }
}
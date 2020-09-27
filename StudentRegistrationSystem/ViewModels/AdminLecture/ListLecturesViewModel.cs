using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels.AdminLecture
{
    public class ListLecturesViewModel
    {
        public List<DepartmentLecturesViewModel> departmentLecturesViewModels { get; set; }

        public ListLecturesViewModel(List<DepartmentLecturesViewModel> departmentLecturesViewModels)
        {
            this.departmentLecturesViewModels = departmentLecturesViewModels;
        }

        public ListLecturesViewModel()
        {
        }
    }
}
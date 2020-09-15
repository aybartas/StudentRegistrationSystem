using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.ViewModels
{
    public class StudentListViewModel
    {
        public List<StudentRecordViewModel> StudentRecordViewModels  { get; set; }

        public StudentListViewModel(List<StudentRecordViewModel> studentRecordViewModels)
        {
            StudentRecordViewModels = studentRecordViewModels;
        }
    }
}
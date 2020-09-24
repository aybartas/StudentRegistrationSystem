using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentRegistrationSystem.Controllers.Admin
{

    public class ManageLecturerController : Controller
    {
        LecturerHelper lecturerHelper = new LecturerHelper();
        DepartmentHelper departmentHelper = new DepartmentHelper();
        SectionHelper sectionHelper = new SectionHelper();
        StudentHelper studentHelper = new StudentHelper();
        public ActionResult List()
        {
            LecturerListViewModel lecturerListViewModel = new LecturerListViewModel();
            lecturerListViewModel.lecturerlist = lecturerHelper.GetLecturers();
            lecturerListViewModel.departmentList = departmentHelper.GetDepartments();
            return View(lecturerListViewModel);
        }
        [HttpPost]
        public ActionResult Form(LecturerListViewModel lecturerListViewModel)
        {
            lecturerListViewModel.departmentList = departmentHelper.GetDepartments();
            if (ModelState.IsValid)
            {

                Lecturer lecturer = new Lecturer
                {
                    Name = lecturerListViewModel.Name,
                    LastName = lecturerListViewModel.LastName,
                    Phone = lecturerListViewModel.Phone,
                    Email = lecturerListViewModel.Email,
                    DepartmentCode = lecturerListViewModel.DepartmentCode
                };
                lecturerHelper._dbContext.Lecturers.Add(lecturer);
                lecturerHelper._dbContext.SaveChanges();
                TempData["LecturerAddSuccess"] = "Not Null";
                return RedirectToAction("List", "ManageLecturer");
            }

            return View(lecturerListViewModel);
        }
        public ActionResult Form()
        {

            LecturerListViewModel lecturerListViewModel = new LecturerListViewModel();
            lecturerListViewModel.departmentList = departmentHelper.GetDepartments();

            return View(lecturerListViewModel);
        }

        public ActionResult Delete(int LecturerID)
        {
            foreach (User s in studentHelper.GetOnlyStudents())
            {
                if(s.LecturerID == LecturerID)
                {
                    TempData["DeleteStatus"] = "Lecturer is Advisor";
                    s.LecturerID = null;
                    //lecturerHelper._dbContext.Lecturers.Remove(lecturerHelper._dbContext.Lecturers.Find(LecturerID));
                    lecturerHelper._dbContext.Users.AddOrUpdate<User>(s);
                }
            }
            //foreach(Section s in sectionHelper.GetAllSections())
            //{
                //if(s.LecturerID == LecturerID)
                //{
                //    TempData["DeleteStatus2"] = "Lecturer Has a Section";
                //    //lecturerHelper._dbContext.Sections.Attach(s);
                //    //if (!lecturerHelper._dbContext.Sections.Contains(s))
                //    //{
                //    //    lecturerHelper._dbContext.Sections.Attach(s);
                //    //}
                //    Section b = lecturerHelper._dbContext.Sections.Find(s.SectionID);
                //    lecturerHelper._dbContext.Sections.Remove(b);
                //    //lecturerHelper._dbContext.Lecturers.Remove(lecturerHelper._dbContext.Lecturers.Find(LecturerID));
                //    //lecturerHelper._dbContext.SaveChanges();
                //}
            //}
            lecturerHelper._dbContext.Lecturers.Remove(lecturerHelper._dbContext.Lecturers.Find(LecturerID));
            lecturerHelper._dbContext.SaveChanges();
            TempData["LecturerDeleteSuccess"] = "Not Null";
            return RedirectToAction("List", "ManageLecturer");
        }
        public ActionResult Update(int LecturerID)
        {
            Lecturer lecturer = lecturerHelper._dbContext.Lecturers.Find(LecturerID);
            UpdateLecturerViewModel updateLecturerViewModel = new UpdateLecturerViewModel
            {
                lecturer = lecturer,
                LecturerID = LecturerID,
                departmentList = departmentHelper.GetDepartments()                
            };
            return View(updateLecturerViewModel);
        }
        [HttpPost]
        public ActionResult Update(UpdateLecturerViewModel updateLecturerViewModel)
        {
            Lecturer lecturer = lecturerHelper._dbContext.Lecturers.Find(updateLecturerViewModel.LecturerID);
            lecturer.Name = updateLecturerViewModel.Name;
            lecturer.LastName = updateLecturerViewModel.LastName;
            lecturer.Email = updateLecturerViewModel.Email;
            lecturer.DepartmentCode = updateLecturerViewModel.DepartmentCode;
            lecturer.Phone = updateLecturerViewModel.Phone;
            lecturer.LecturerID = updateLecturerViewModel.LecturerID;
            updateLecturerViewModel.lecturer = lecturer;
            updateLecturerViewModel.departmentList = departmentHelper.GetDepartments();
            if (ModelState.IsValid)
            {
                TempData["LecturerUpdateSuccess"] = "Not Null";
                lecturerHelper._dbContext.Lecturers.AddOrUpdate<Lecturer>(lecturer);
                lecturerHelper._dbContext.SaveChanges();
                return RedirectToAction("List", "ManageLecturer");
            }
            else
            {
                return View(updateLecturerViewModel);
            }
        }
        public ActionResult Courses(int LecturerID)
        {
            UpdateLecturerViewModel updateLecturerViewModel = new UpdateLecturerViewModel();
            List<Section> sectionList = sectionHelper.GetAllSections();
            List<Section> lecturersSectionList = new List<Section>();
            foreach (Section s in sectionList)
            {
                if (s.LecturerID == LecturerID)
                {
                    lecturersSectionList.Add(s);
                }
            }
            updateLecturerViewModel.sectionsGiven = lecturersSectionList;
            updateLecturerViewModel.lecturer = lecturerHelper._dbContext.Lecturers.Find(LecturerID);
            updateLecturerViewModel.allDepartmentalLectures = lecturerHelper.GetAllLecturesOfLecturersDepartment(LecturerID);
            return View(updateLecturerViewModel);
        }
        //[HttpPost]
        //public ActionResult GetSectionsFromLecturesForLecturer(int LectureID)
        //{

        //    List<Section> dropdownSections = sectionHelper.GetSectionsOfLecture(LectureID);

        //    SelectList sections = new SelectList(dropdownSections, "SectionID", "Number", 0);
        //    return Json(sections);
        //}
        //public ActionResult AddSection(int LecturerID, int ddlSection)
        //{
        //    Section section = sectionHelper._dbContext.Sections.Find(ddlSection);

        //    if (section.LecturerID == null)
        //    {

        //    }
        //}
    }
}

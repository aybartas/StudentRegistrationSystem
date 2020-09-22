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
        public ActionResult List()
        {
            LecturerListViewModel lecturerListViewModel = new LecturerListViewModel();
            lecturerListViewModel.lecturerlist = lecturerHelper.GetLecturers();
            lecturerListViewModel.departmentList = departmentHelper.GetDepartments();
            return View(lecturerListViewModel);
        }
        [HttpPost]
        public ActionResult AddLecturer(LecturerListViewModel lecturerListViewModel)
        {
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

            return RedirectToAction("List", "ManageLecturer");
        }
        public ActionResult Form()
        {

            LecturerListViewModel lecturerListViewModel = new LecturerListViewModel();
            lecturerListViewModel.departmentList = departmentHelper.GetDepartments();

            return View(lecturerListViewModel);
        }

        public ActionResult Delete(int LecturerID)
        {
            TempData["LecturerDeleteSuccess"] = "Not Null";
            lecturerHelper._dbContext.Lecturers.Remove(lecturerHelper._dbContext.Lecturers.Find(LecturerID));
            lecturerHelper._dbContext.SaveChanges();
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
            if (ModelState.IsValid)
            {
                TempData["LecturerUpdateSuccess"] = "Not Null";
                lecturerHelper._dbContext.Lecturers.AddOrUpdate<Lecturer>(lecturer);
                lecturerHelper._dbContext.SaveChanges();
                return RedirectToAction("List", "ManageLecturer");
            }
            else
            {
                return RedirectToAction("Update", "ManageLecturer");
            }
        }
        public ActionResult Courses(int LecturerID)
        {
            UpdateLecturerViewModel updateLecturerViewModel = new UpdateLecturerViewModel();
            List<Section> sectionList = sectionHelper.GetAllSections();
            List<Section> lecturersSectionList = new List<Section>();
            foreach (Section s in sectionList){
                if(s.LecturerID == LecturerID)
                {
                    lecturersSectionList.Add(s);
                }
            }
            updateLecturerViewModel.sectionsGiven = lecturersSectionList;
            updateLecturerViewModel.lecturer = lecturerHelper._dbContext.Lecturers.Find(LecturerID);
            updateLecturerViewModel.allDepartmentalLectures = lecturerHelper.GetAllLecturesOfLecturersDepartment(LecturerID);
            return View(updateLecturerViewModel);
        }
        [HttpPost]
        public ActionResult GetSectionsFromLecturesForLecturer(int LectureID)
        {

            List<Section> dropdownSections = sectionHelper.GetSectionsOfLecture(LectureID);

            SelectList sections = new SelectList(dropdownSections, "SectionID", "Number", 0);
            return Json(sections);
        }
    }
}

using StudentRegistrationSystem.Helpers;
using StudentRegistrationSystem.Models.Entity;
using StudentRegistrationSystem.ViewModels.AdminLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace StudentRegistrationSystem.Controllers.Admin
{
    public class ManageLectureController : Controller
    {
        StudentHelper studentHelper = new StudentHelper();
        DepartmentHelper departmentHelper = new DepartmentHelper();
        LecturerHelper lecturerHelper = new LecturerHelper();
        SectionHelper sectionHelper = new SectionHelper();
        EnrollmentHelper enrollmentHelper = new EnrollmentHelper();
        LectureHelper lectureHelper = new LectureHelper();

        // GET: ManageLecture
        public ActionResult List()
        {

            List<DepartmentLecturesViewModel> departmentLectures = new List<DepartmentLecturesViewModel>();

            List<Department> departments = departmentHelper.GetDepartments();
            foreach(Department department in departments)
            {
                List<Lecture> lecturesOfDepartment = lectureHelper.GetLectures().Where(m => m.DepartmentCode.Equals(department.DepartmentCode)).ToList();
                DepartmentLecturesViewModel departmentLecturesViewModel = new DepartmentLecturesViewModel(department, lecturesOfDepartment);
                departmentLectures.Add(departmentLecturesViewModel);
            }

            ListLecturesViewModel listLecturesViewModel = new ListLecturesViewModel(departmentLectures);

            return View(listLecturesViewModel);
        }

        public ActionResult UpdateLecture(int LectureID)
        {
            Lecture currentLecture = lectureHelper._dbContext.Lectures.Find(LectureID);
            List<Section> sectionsOfCurrentLecture = sectionHelper._dbContext.Sections.Where(m => m.LectureID.Equals(LectureID)).ToList();
            string departmentNameOfCurrentLecture = departmentHelper._dbContext.Departments.Find(currentLecture.DepartmentCode).Name;
            AddSectionFormViewModel addSectionFormViewModel = new AddSectionFormViewModel();
            UpdateLectureFormViewModel updateLectureFormViewModel = new UpdateLectureFormViewModel();
            UpdateSectionFormViewModel updateSectionFormViewModel = new UpdateSectionFormViewModel();
            List<Lecturer> lecturers = lecturerHelper._dbContext.Lecturers.Where(m => m.DepartmentCode.Equals(currentLecture.DepartmentCode)).ToList();
            UpdateLectureViewModel updateLectureViewModel = new UpdateLectureViewModel(currentLecture,sectionsOfCurrentLecture,departmentNameOfCurrentLecture,updateLectureFormViewModel,addSectionFormViewModel,updateSectionFormViewModel,lecturers);
            
            return View(updateLectureViewModel);
        }

        [HttpPost]
        public ActionResult UpdateSection(UpdateLectureViewModel updateLectureViewModel, int SectionID)
        {

            Section section = sectionHelper._dbContext.Sections.
                Include(s => s.Enrollments).FirstOrDefault(x => x.SectionID == SectionID);

            Lecture lecture = lectureHelper._dbContext.Lectures.Where(x => x.LectureID == section.LectureID).Include(m => m.Sections).FirstOrDefault();
            Lecturer lecturer = lecturerHelper._dbContext.Lecturers.Find(updateLectureViewModel.updateSectionFormViewModel.LecturerID);
            List<Section> currentSections = sectionHelper._dbContext.Sections.Where(m => m.LectureID == lecture.LectureID && m.SectionID != section.SectionID ).ToList();

            foreach (Section counterSection in currentSections)
            {
                if (counterSection.Number == updateLectureViewModel.updateSectionFormViewModel.Number)
                {
                    TempData["UpdateSectionStatus"] = "NumberExists";
                    return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

                }
            }

            if (!(Convert.ToDouble(updateLectureViewModel.updateSectionFormViewModel.Time.Replace(".", ",")) < Convert.ToDouble(updateLectureViewModel.updateSectionFormViewModel.EndTime.Replace(".", ","))))
            {
                // start time end time error
                TempData["UpdateSectionStatus"] = "StartTimeError";
                return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });
            }

            foreach (Section sectionOfLecturer in lecturer.Sections.Where(s=>s.SectionID !=section.SectionID))
            {
                if (sectionOfLecturer.Day.Equals(updateLectureViewModel.updateSectionFormViewModel.Day))
                {
                    double startTimeOfExistingSection = Convert.ToDouble(sectionOfLecturer.Time.Replace(".", ","));
                    double endTimeOfExistingSection = Convert.ToDouble(sectionOfLecturer.EndTime.Replace(".", ","));
                    double startTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.updateSectionFormViewModel.Time.Replace(".", ","));
                    double endTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.updateSectionFormViewModel.EndTime.Replace(".", ","));
                    if (!((startTimeOfExistingSection.CompareTo(endTimeOfNewSection) > 1) || (endTimeOfExistingSection.CompareTo(startTimeOfNewSection) < 0)))
                    {
                        TempData["UpdateSectionStatus"] = "LecturerOccupied";
                        return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

                    }
                }
            }

            List<Section> allSections = sectionHelper._dbContext.Sections.
                Where(m => m.Day == updateLectureViewModel.addSectionFormViewModel.Day &&
                m.Building == updateLectureViewModel.addSectionFormViewModel.Building &&
                m.Classroom == updateLectureViewModel.addSectionFormViewModel.Classroom &&
                m.SectionID != section.SectionID).ToList();
            foreach (Section s in allSections)
            {
                double startTimeOfExistingSection = Convert.ToDouble(s.Time.Replace(".", ","));
                double endTimeOfExistingSection = Convert.ToDouble(s.EndTime.Replace(".", ","));
                double startTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.updateSectionFormViewModel.Time.Replace(".", ","));
                double endTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.updateSectionFormViewModel.EndTime.Replace(".", ","));
                if (!((startTimeOfExistingSection.CompareTo(endTimeOfNewSection) > 1) || (endTimeOfExistingSection.CompareTo(startTimeOfNewSection) < 0)))
                {
                    TempData["UpdateSectionStatus"] = "AnotherSectionOppuied";
                    return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

                }
            }

            section.Number = updateLectureViewModel.updateSectionFormViewModel.Number;
            section.LecturerID = updateLectureViewModel.updateSectionFormViewModel.LecturerID;
            section.Time = updateLectureViewModel.updateSectionFormViewModel.Time;
            section.EndTime = updateLectureViewModel.updateSectionFormViewModel.EndTime;
            section.Day = updateLectureViewModel.updateSectionFormViewModel.Day;
            section.Quota = updateLectureViewModel.updateSectionFormViewModel.Quota;
            section.Time = updateLectureViewModel.updateSectionFormViewModel.Time;
            section.Building = updateLectureViewModel.updateSectionFormViewModel.Building;
            section.Classroom = updateLectureViewModel.updateSectionFormViewModel.Classroom;
          

            if (ModelState.IsValid)
            {
                TempData["UpdateSectionStatus"] = "Successful";
                sectionHelper._dbContext.Sections.AddOrUpdate(section);
                sectionHelper._dbContext.SaveChanges();
                return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });
            }
            else
            {

                return View(updateLectureViewModel);
            }
        }

        [HttpPost]
        public ActionResult UpdateLecture(UpdateLectureViewModel updateLectureViewModel,int LectureID)
        {

            Lecture lecture = lectureHelper._dbContext.Lectures.
                Include(l => l.Sections.Select(s => s.Enrollments)).FirstOrDefault(x => x.LectureID == LectureID);

            List<Lecture> allLecturesExceptCurrent = lectureHelper._dbContext.Lectures.
                Where(m => m.Name.Equals(lecture.Name) && m.EducationType.Equals(updateLectureViewModel.updateLectureFormViewModel.EducationType) 
                && m.LectureID != lecture.LectureID).ToList(); 
            if(allLecturesExceptCurrent.Count>0)
            {
                TempData["UpdateLectureStatus"] = "Invalid";
                return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });
            }
            string previousEducationType = lecture.EducationType;
            lecture.LectureCode = updateLectureViewModel.updateLectureFormViewModel.LectureCode;
            lecture.Name = updateLectureViewModel.updateLectureFormViewModel.Name;
            lecture.Term = updateLectureViewModel.updateLectureFormViewModel.Term;
            lecture.EducationType = updateLectureViewModel.updateLectureFormViewModel.EducationType;
            lecture.Credit = updateLectureViewModel.updateLectureFormViewModel.Credit;

            if (ModelState.IsValid)
            {

                if (previousEducationType.Equals(lecture.EducationType))
                {
                    TempData["UpdateLectureStatus"] = "Successful";
                    lectureHelper._dbContext.Lectures.AddOrUpdate<Lecture>(lecture);
                    lectureHelper._dbContext.SaveChanges();
                    return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID } );
                }

                foreach(Section s in lecture.Sections)
                {
                    if(s!= null)
                    {

                        foreach (Enrollment e in s.Enrollments)
                        {
                            if (e != null && e.Grade == null)
                            {
                                Enrollment enrollmentToBeDeleted = enrollmentHelper._dbContext.Enrollments.Find(e.EnrollmentID);
                                enrollmentHelper._dbContext.Enrollments.Remove(enrollmentToBeDeleted);
                                enrollmentHelper._dbContext.SaveChanges();
                            }

                        }
                    }
                 
                }

                lectureHelper._dbContext.Lectures.AddOrUpdate<Lecture>(lecture);
                lectureHelper._dbContext.SaveChanges();
                TempData["UpdateLectureStatus"] = "Successful";
                return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

            }
            else
            {

                return View(updateLectureViewModel);
            }


        }


        public ActionResult AddLecture(string DepartmentCode)
        {
            AddLectureViewModel addLectureViewModel = new AddLectureViewModel();
            addLectureViewModel.DepartmentCode = DepartmentCode;
            Department department = departmentHelper._dbContext.Departments.Find(DepartmentCode);
            List<Lecturer> lecturers = lecturerHelper._dbContext.Lecturers.Where(m => m.DepartmentCode == DepartmentCode).ToList();
            addLectureViewModel.department = department;
            addLectureViewModel.lecturers = lecturers;



            return View(addLectureViewModel);
        }



        [HttpPost]
        public ActionResult AddLecture(AddLectureViewModel addLectureViewModel, string DepartmentCode)
        {

            List<Lecture> currentLectures = lectureHelper._dbContext.Lectures.Where(l => l.DepartmentCode.Equals(DepartmentCode) &&
            l.LectureCode == addLectureViewModel.LectureCode && l.EducationType.Equals(addLectureViewModel.EducationType)).ToList();
            if (currentLectures.Count > 0)
            {
                TempData["AddLectureStatus"] = "LectureExists";
                return RedirectToAction("AddLecture", "ManageLecture", new { DepartmentCode });
            }


            Lecture lecture = new Lecture
            {
                Name = addLectureViewModel.Name,
                LectureCode = addLectureViewModel.LectureCode,
                EducationType = addLectureViewModel.EducationType,
                Credit = addLectureViewModel.Credit,
                Term = addLectureViewModel.Term,
                DepartmentCode = DepartmentCode
            };


            lectureHelper.AddLecture(lecture);
            TempData["AddLectureStatus"] = "Successful";


            return RedirectToAction("List", "ManageLecture");

        }


        [HttpPost]
        public ActionResult AddSection(UpdateLectureViewModel updateLectureViewModel, int LectureID)
        {
            Lecture lecture = lectureHelper._dbContext.Lectures.Where(x => x.LectureID == LectureID).Include(m => m.Sections).FirstOrDefault();
            Lecturer lecturer = lecturerHelper._dbContext.Lecturers.Find(updateLectureViewModel.addSectionFormViewModel.LecturerID);
            List<Section> currentSections = sectionHelper._dbContext.Sections.Where(m => m.LectureID == LectureID).ToList();
            
            foreach(Section counterSection in currentSections)
            {
                if(counterSection.Number == updateLectureViewModel.addSectionFormViewModel.Number)
                {
                    TempData["AddSectionStatus"] = "NumberExists";
                    return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

                }
            }

            if(!(Convert.ToDouble(updateLectureViewModel.addSectionFormViewModel.Time.Replace(".",",")) < Convert.ToDouble(updateLectureViewModel.addSectionFormViewModel.EndTime.Replace(".", ","))))
            {
                // start time end time error
                TempData["AddSectionStatus"] = "StartTimeError";
                return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });
            }
            foreach(Section sectionOfLecturer in lecturer.Sections)
            {
                if (sectionOfLecturer.Day.Equals(updateLectureViewModel.addSectionFormViewModel.Day))
                {
                    double startTimeOfExistingSection = Convert.ToDouble(sectionOfLecturer.Time.Replace(".", ","));
                    double endTimeOfExistingSection = Convert.ToDouble(sectionOfLecturer.EndTime.Replace(".", ","));
                    double startTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.addSectionFormViewModel.Time.Replace(".", ","));
                    double endTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.addSectionFormViewModel.EndTime.Replace(".", ","));
                    if (!((startTimeOfExistingSection.CompareTo(endTimeOfNewSection) > 1) || (endTimeOfExistingSection.CompareTo(startTimeOfNewSection) < 0)))
                    {
                        TempData["AddSectionStatus"] = "LecturerOccupied";
                        return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

                    }
                }
            }

            List<Section> allSections = sectionHelper._dbContext.Sections.
                Where(m => m.Day == updateLectureViewModel.addSectionFormViewModel.Day &&
                m.Building == updateLectureViewModel.addSectionFormViewModel.Building &&
                m.Classroom == updateLectureViewModel.addSectionFormViewModel.Classroom).ToList();
           foreach(Section s in allSections)
            {
                double startTimeOfExistingSection = Convert.ToDouble(s.Time.Replace(".", ","));
                double endTimeOfExistingSection = Convert.ToDouble(s.EndTime.Replace(".", ","));
                double startTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.addSectionFormViewModel.Time.Replace(".", ","));
                double endTimeOfNewSection = Convert.ToDouble(updateLectureViewModel.addSectionFormViewModel.EndTime.Replace(".", ","));
                if (!((startTimeOfExistingSection.CompareTo(endTimeOfNewSection) > 1) || (endTimeOfExistingSection.CompareTo(startTimeOfNewSection) < 0)))
                {
                    TempData["AddSectionStatus"] = "AnotherSectionOppuied";
                    return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

                }
            }
           
            Section newSection = new Section {Number=updateLectureViewModel.addSectionFormViewModel.Number,
            Time = updateLectureViewModel.addSectionFormViewModel.Time,
            EndTime=updateLectureViewModel.addSectionFormViewModel.EndTime,
            Day=updateLectureViewModel.addSectionFormViewModel.Day,
            Quota =updateLectureViewModel.addSectionFormViewModel.Quota,
            Building=updateLectureViewModel.addSectionFormViewModel.Building,
            Classroom=updateLectureViewModel.addSectionFormViewModel.Classroom,
            LecturerID = updateLectureViewModel.addSectionFormViewModel.LecturerID,
            LectureID = LectureID };

            sectionHelper.AddSection(newSection);
            TempData["AddSectionStatus"] = "Succesfull";
            return RedirectToAction("UpdateLecture", "ManageLecture", new { lecture.LectureID });

        }

        public ActionResult DeleteSection(int SectionID,int LectureID)
        {


            sectionHelper._dbContext.Sections.Remove(sectionHelper._dbContext.Sections.Find(SectionID));
            sectionHelper._dbContext.SaveChanges();
            TempData["SectionDeleteStatus"] = "Success";

            return RedirectToAction("UpdateLecture", "ManageLecture", new { LectureID });
        }

        public ActionResult Delete(int LectureID)
        {

            lectureHelper._dbContext.Lectures.Remove(lectureHelper._dbContext.Lectures.Find(LectureID));
            lectureHelper._dbContext.SaveChanges();
            TempData["LectureDeleteStatus"] = "Success";

            return RedirectToAction("List", "ManageLecture");
        }
    }
}
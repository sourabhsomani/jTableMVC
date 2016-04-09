using jTableMVC.Entities;
using jTableMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jTableMVC.Controllers
{
    public class MarksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStudentMarks(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                List<Marks> lstMarks = new List<Marks>();
                lstMarks = db.Marks.ToList();
                switch (jtSorting)
                {
                    case "RollNumber ASC":
                        lstMarks = lstMarks.OrderBy(t => t.RollNumber).ToList();
                        break;
                    case "RollNumber DESC":
                        lstMarks = lstMarks.OrderByDescending(t => t.RollNumber).ToList();
                        break;
                    case "Name ASC":
                        lstMarks = lstMarks.OrderBy(t => t.Name).ToList();
                        break;
                    case "Name DESC":
                        lstMarks = lstMarks.OrderByDescending(t => t.Name).ToList();
                        break;
                    case "MarksObtained ASC":
                        lstMarks = lstMarks.OrderBy(t => t.MarksObtained).ToList();
                        break;
                    case "MarksObtained DESC":
                        lstMarks = lstMarks.OrderByDescending(t => t.MarksObtained).ToList();
                        break;
                }

                lstMarks = lstMarks.Skip(jtStartIndex).Take(jtPageSize).ToList();
                int TotalRecords = db.Marks.Count();
                return Json(new { Result = "OK", Records = lstMarks, TotalRecordCount = TotalRecords });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Create(Marks Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                Model.ID = Guid.NewGuid().ToString();
                db.Marks.Add(Model);
                db.SaveChanges();
                return Json(new { Result = "OK", Records = Model }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Edit(Marks Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                db.Entry(Model).State = EntityState.Modified;
                db.SaveChanges(); 
                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Delete(String ID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                Marks marks = db.Marks.Find(ID);
                db.Marks.Remove(marks);
                db.SaveChanges();
                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}
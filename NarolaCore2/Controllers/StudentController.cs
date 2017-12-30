using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NarolaCore2.Data;
using NarolaCore2.Models;

namespace NarolaCore2.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Students.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            if (id < 0)
            {
                return RedirectToAction("Index");
            }
            var objData = _context.Students.FirstOrDefault(x => x.ID == id);
            if (objData == null)
            {
                return RedirectToAction("Index");
            }
            return View(objData);
        }

        [HttpPost]
        public ActionResult Edit(Student model)
        {
            var objData = _context.Students.FirstOrDefault(x => x.ID == model.ID);
            if (objData != null)
            {
                objData.EnrollmentDate = model.EnrollmentDate;
                objData.LastName = model.LastName;
                objData.FirstMidName = model.FirstMidName;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            var objData = _context.Students.FirstOrDefault(x => x.ID == id);
            if (objData != null)
            {
                _context.Students.Remove(objData);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
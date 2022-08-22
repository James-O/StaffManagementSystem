using StaffManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffManagementSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        public ActionResult Department()
        {
            using (StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {

                var dept = db.DepartmentTbs.ToList();
                return View(dept);
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentsModel department)
        {
            DepartmentTb dept = new DepartmentTb()
            {
                DeparmentTbName = department.DeparmentTbName,
                departmentTbDescription = department.departmentTbDescription,
                createdBy = department.createdBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = department.UpdatedBy,
                UpdatedOn = DateTime.Now
            };
            if (ModelState.IsValid)
            {
                using (StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
                {
                    db.DepartmentTbs.Add(dept);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = "Department created successfully";
                }
            }
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                var edit = db.DepartmentTbs.FirstOrDefault(m=>m.DepartmentTbId == id);
                return View(edit);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentTb department)
        {
            if (ModelState.IsValid)
            {
                using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
                {
                    db.Entry(department).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Department");
                }
            }
            return View(department);
        }
    }
}
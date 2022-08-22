using StaffManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffManagementSystem.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: Resources
        public ActionResult Home()
        {
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                var res = db.ResourcesTbs.ToList();
                return View(res);
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResourcesModel resources)
        {
            ResourcesTb res = new ResourcesTb()
            {
                ResourcesTbName = resources.ResourcesTbName,
                ResourcesTbDescription = resources.ResourcesTbDescription,
                CreatedBy = resources.CreatedBy,
                CreatedOn = DateTime.Now,
                UpdatedBy = resources.UpdatedBy,
                UpdatedOn = DateTime.Now
            };
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                if (ModelState.IsValid)
                {
                    db.ResourcesTbs.Add(res);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = "Resources added successfully";
                }
            }
            return View();
        }
    }
}
using StaffManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StaffManagementSystem.Controllers
{
    public class StaffsController : Controller
    {
        // GET: Staffs
        public ActionResult StaffDetail()
        {
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                return View(db.StaffTbs.ToList());
            }
            
        }
        public ActionResult Delete(int? id)
        {
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                var record = db.StaffTbs.Find(id);
                return View(record);
            }
            
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                db.StaffTbs.Remove(db.StaffTbs.Find(id));
                db.SaveChanges();
                return RedirectToAction("StaffDetail");
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
                
        }
        public ActionResult Edit(int? id)
        {
            using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
            {
                //var edit = db.StaffTbs.Where(a => a.StaffId == id).FirstOrDefault();
                //return View(edit);
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                StaffTb movie = db.StaffTbs.Find(id);
                if (movie == null)
                {
                    return HttpNotFound();
                }
                return View(movie);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="StaffId,FirstName,LastName,Email,Password,Address,CreatedOn,sUpdatedOn")]StaffTb staff)
        {
            if (ModelState.IsValid)
            {
                using(StaffMgtSysDbEntities db = new StaffMgtSysDbEntities())
                {
                    db.Entry(staff).State = EntityState.Modified;
                    db.SaveChanges();
                    //var rmstaff = db.StaffTbs.Where(a => a.StaffId == staff.StaffId).FirstOrDefault();
                    //db.StaffTbs.Remove(rmstaff);
                    //db.StaffTbs.Add(staff);
                    return RedirectToAction("StaffDetail");
                }
            }
            return View(staff);
        }
    }
}
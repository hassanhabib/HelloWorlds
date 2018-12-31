using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelloWorlds.Web.Models;
using HelloWorlds.Web.Services;

namespace HelloWorlds.Web.Controllers
{
    public class CodesController : Controller
    {
        private Storage db = new Storage();

        // GET: Codes
        public ActionResult Index()
        {
            return View(db.Codes.ToList());
        }

        // GET: Codes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }

        // GET: Codes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Codes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,OriginalSource,SourceCode,Language,ProgrammingLanguage,Date,User,Visibility")] Code code)
        {
            code.SourceCode = new CodeTranslationService().GetNativeSourceCode(code);

            if (ModelState.IsValid)
            {
                code.Id = Guid.NewGuid();
                db.Codes.Add(code);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = code.Id});
            }

            return View(code);
        }

        // GET: Codes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }

        // POST: Codes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,OriginalSource,SourceCode,Language,ProgrammingLanguage,Date,User,Visibility")] Code code)
        {
            if (ModelState.IsValid)
            {
                db.Entry(code).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(code);
        }

        // GET: Codes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code code = db.Codes.Find(id);
            if (code == null)
            {
                return HttpNotFound();
            }
            return View(code);
        }

        // POST: Codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Code code = db.Codes.Find(id);
            db.Codes.Remove(code);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

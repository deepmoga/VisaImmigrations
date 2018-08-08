using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using visa.Models;

namespace visa.Controllers
{
    public class TemplatesController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Templates
        public async Task<ActionResult> Index()
        {
            return View(await db.Templates.ToListAsync());
        }

        // GET: Templates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Templates templates = await db.Templates.FindAsync(id);
            if (templates == null)
            {
                return HttpNotFound();
            }
            return View(templates);
        }

        // GET: Templates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Templates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Templateid,Title,Template")] Templates templates)
        {
            if (ModelState.IsValid)
            {
                db.Templates.Add(templates);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(templates);
        }

        // GET: Templates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Templates templates = await db.Templates.FindAsync(id);
            if (templates == null)
            {
                return HttpNotFound();
            }
            return View(templates);
        }

        // POST: Templates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Templateid,Title,Template")] Templates templates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(templates).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(templates);
        }

        // GET: Templates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Templates templates = await db.Templates.FindAsync(id);
            if (templates == null)
            {
                return HttpNotFound();
            }
            return View(templates);
        }

        // POST: Templates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Templates templates = await db.Templates.FindAsync(id);
            db.Templates.Remove(templates);
            await db.SaveChangesAsync();
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

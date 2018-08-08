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
    public class DocsController : Controller
    {
        private dbcontext db = new dbcontext();
        public static string img, code;
        // GET: Docs
        public async Task<ActionResult> Index()
        {
            var docs = db.Docs.Include(d => d.preforms);
            return View(await docs.ToListAsync());
        }

        // GET: Docs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docs docs = await db.Docs.FindAsync(id);
            
            if (docs == null)
            {
                return HttpNotFound();
            }
            return View(docs);
        }

        // GET: Docs/Create
        public ActionResult Create()
        {
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName");
            return View();
        }

        // POST: Docs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,DocName,Documents,Preformid")] Docs docs, IEnumerable<HttpPostedFileBase> file, Helper help)
        {
            if (ModelState.IsValid)
            {
                foreach (var f in file)
                {
                    docs.Documents = help.uploadfile(f);
                    db.Docs.Add(docs);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", docs.Preformid);
            return View(docs);
        }

        // GET: Docs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docs docs = await db.Docs.FindAsync(id);
            img = docs.Documents;

            if (docs == null)
            {
                return HttpNotFound();
            }
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", docs.Preformid);
            return View(docs);
        }

        // POST: Docs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,DocName,Documents,Preformid")] Docs docs,HttpPostedFileBase file, Helper help)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", docs.Preformid);
            return View(docs);
        }

        // GET: Docs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docs docs = await db.Docs.FindAsync(id);
            if (docs == null)
            {
                return HttpNotFound();
            }
            return View(docs);
        }

        // POST: Docs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Docs docs = await db.Docs.FindAsync(id);
            db.Docs.Remove(docs);
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

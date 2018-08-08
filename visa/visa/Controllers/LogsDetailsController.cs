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
using System.Web.Script.Serialization;

namespace visa.Controllers
{
    public class LogsDetailsController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: LogsDetails
        public async Task<ActionResult> Index()
        {
            var logsDetails = db.LogsDetails.Include(l => l.preforms).Include(l => l.Templates);
            return View(await logsDetails.ToListAsync());
        }

        // GET: LogsDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogsDetails logsDetails = await db.LogsDetails.FindAsync(id);
            if (logsDetails == null)
            {
                return HttpNotFound();
            }
            return View(logsDetails);
        }

        // GET: LogsDetails/Create
        public ActionResult Create()
        {
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName");
            ViewBag.Templateid = new SelectList(db.Templates, "Templateid", "Title");
            return View();
        }

        // POST: LogsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Logsid,Date,Time,Templateid,Message,Sender,Preformid")] LogsDetails logsDetails,string message, Helper help, string email)
        {
            if (ModelState.IsValid)
            {
                logsDetails.Date = System.DateTime.Now.ToShortDateString();
                logsDetails.Time = System.DateTime.Now.ToShortTimeString();
                logsDetails.Message = message;
                db.LogsDetails.Add(logsDetails);
                await db.SaveChangesAsync();
                if (email != null)
                {
                    PreForm stud = db.PreForms.Find(logsDetails.Preformid);
                    Templates tt = db.Templates.Find(logsDetails.Templateid);
                    if (stud.Email != null)
                    {
                        // send logs to client by email
                        string body = help.PopulateBody(stud.StudentName, tt.Title, "", logsDetails.Message);
                        help.SendHtmlFormattedEmail(stud.Email, tt.Template, body);

                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", logsDetails.Preformid);
            ViewBag.Templateid = new SelectList(db.Templates, "Templateid", "Title", logsDetails.Templateid);
            return View(logsDetails);
        }

        // GET: LogsDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogsDetails logsDetails = await db.LogsDetails.FindAsync(id);
            if (logsDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", logsDetails.Preformid);
            ViewBag.Templateid = new SelectList(db.Templates, "Templateid", "Title", logsDetails.Templateid);
            return View(logsDetails);
        }

        // POST: LogsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Logsid,Date,Time,Templateid,Message,Sender,Preformid")] LogsDetails logsDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logsDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", logsDetails.Preformid);
            ViewBag.Templateid = new SelectList(db.Templates, "Templateid", "Title", logsDetails.Templateid);
            return View(logsDetails);
        }

        // GET: LogsDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogsDetails logsDetails = await db.LogsDetails.FindAsync(id);
            if (logsDetails == null)
            {
                return HttpNotFound();
            }
            return View(logsDetails);
        }

        // POST: LogsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LogsDetails logsDetails = await db.LogsDetails.FindAsync(id);
            db.LogsDetails.Remove(logsDetails);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        public ActionResult Tempdata(int stateID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Templates> lstcity = new List<Templates>();

            lstcity = (db.Templates.Where(x => x.Templateid == stateID)).ToList();
            
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(lstcity);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

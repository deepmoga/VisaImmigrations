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
    public class ProcessingFormsController : BaseController
    {
        private dbcontext db = new dbcontext();

        // GET: ProcessingForms
        public async Task<ActionResult> Index()
        {
            var processingForms = db.ProcessingForms.Include(p => p.preforms);
            return View(await processingForms.ToListAsync());
        }

        // GET: ProcessingForms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessingForm processingForm = await db.ProcessingForms.FindAsync(id);
            if (processingForm == null)
            {
                return HttpNotFound();
            }
            return View(processingForm);
        }

        // GET: ProcessingForms/Create
        public ActionResult Create()
        {
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName");
            return View();
        }

        // POST: ProcessingForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Formid,Preformid,OfferLetterFee,AppliedDate,RecivedDate,ProcessingFee,ProcessAlertDate,CollegeFee,CollegeAlertDate,GICFee,GICAlertDate,EmedicalFee,AppointmentDate,EmbassyFee,EmbassyAlertDate,TrackingId")] ProcessingForm processingForm)
        {
            if (ModelState.IsValid)
            {
                var pf = db.ProcessingForms.FirstOrDefault(x => x.Formid == processingForm.Formid);
                if (pf != null)
                {

                    // ViewBag.message = "Yes";
                    //  this.SetNotification("You Already Filled A Form. You Can Only Edit This Form . Go to Edit page And Edit", NotificationEnumeration.Warning);
                    TempData["Warning"] = "You Already Filled A Form. You Can Only Edit This Form . Go to Edit page And Edit";
                    return View(pf);
                }
                else
                {
                  
                    db.ProcessingForms.Add(processingForm);
                    await db.SaveChangesAsync();
                    // this.SetNotification("Your File Created Successfully", NotificationEnumeration.Warning);
                    TempData["Sucess"] = "Your File Created Successfully";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", processingForm.Preformid);
            return View(processingForm);
        }

        // GET: ProcessingForms/Edit/5
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessingForm processingForm = await db.ProcessingForms.FindAsync(id);
            if (processingForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", processingForm.Preformid);
            return View(processingForm);
        }

        // POST: ProcessingForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Formid,Preformid,OfferLetterFee,AppliedDate,RecivedDate,ProcessingFee,ProcessAlertDate,CollegeFee,CollegeAlertDate,GICFee,GICAlertDate,EmedicalFee,AppointmentDate,EmbassyFee,EmbassyAlertDate,TrackingId")] ProcessingForm processingForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processingForm).State = EntityState.Modified;
                await db.SaveChangesAsync();
               // this.SetNotification("Your Fees Form Edit Sucessfully.", NotificationEnumeration.Success);
                TempData["Sucess"] = "Your Fees Form Edit Sucessfully.";
                return RedirectToAction("Index");
            }
            ViewBag.Preformid = new SelectList(db.PreForms, "Preformid", "StudentName", processingForm.Preformid);
            return View(processingForm);
        }

        // GET: ProcessingForms/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessingForm processingForm = await db.ProcessingForms.FindAsync(id);
            if (processingForm == null)
            {
                return HttpNotFound();
            }
            return View(processingForm);
        }

        // POST: ProcessingForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProcessingForm processingForm = await db.ProcessingForms.FindAsync(id);
            db.ProcessingForms.Remove(processingForm);
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

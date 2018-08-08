using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using visa.Models;
namespace visa.Controllers
{
    public class DefaultController : BaseController
    {
        dbcontext db = new dbcontext();
        public string output;
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Processing()
        {
            DateTime NowDate = System.DateTime.Now;
            List<ProcessingForm> aa = new List<ProcessingForm>();
            dynamic model = new ExpandoObject();
            var data = (from t in db.ProcessingForms.Where(x => x.ProcessAlertDate <= NowDate)
                        join sc in db.PreForms on t.Formid equals sc.Preformid

                        select new { Studentid=sc.Preformid,Name = sc.StudentName, Father = sc.FatherName, Contact = sc.ContactNo, Fee = t.ProcessingFee, AlertDate = t.ProcessAlertDate }).ToList();
            List<ExpandoObject> joinData = new List<ExpandoObject>();
            foreach (var item in data)
            {
                IDictionary<string, object> itemExpando = new ExpandoObject();
                foreach (PropertyDescriptor property
                         in
                         TypeDescriptor.GetProperties(item.GetType()))
                {
                    itemExpando.Add(property.Name, property.GetValue(item));
                }
                joinData.Add(itemExpando as ExpandoObject);
            }

            model.JoinData = joinData;
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SMS(int id, Helper help, string Message,int status)
        {
            PreForm pp = db.PreForms.Where(x => x.Preformid == id).First();
            ProcessingForm pf = db.ProcessingForms.Where(x => x.Preformid == id).First();
            OfficeDetail of = db.OfficeDetails.FirstOrDefault();
            if (status == 1)
            {
                // processing fee sms
                output = help.smssetting(pp.ContactNo, "Dear " + pp.StudentName + ". Your Processing Fees is:" + pf.ProcessingFee + " and your Due Date Is : " + pf.ProcessAlertDate + " Thanks and Regards " + of.CompanyName + "");
            }
            else if (status == 2)
            {
                // college fee alert
                output = help.smssetting(pp.ContactNo, "Dear " + pp.StudentName + ". Your College Fees is:" + pf.CollegeFee + " and your Due Date Is : " + pf.CollegeAlertDate + " Thanks and Regards " + of.CompanyName + "");

            }
            else if (status == 3)
            {
                // GIC fee alert
                output = help.smssetting(pp.ContactNo, "Dear " + pp.StudentName + ". Your GIC Fees is:" + pf.GICFee + " and your Due Date Is : " + pf.GICAlertDate + " Thanks and Regards " + of.CompanyName + "");

            }
            else if (status == 3)
            {
                // Embassy fee alert
                output = help.smssetting(pp.ContactNo, "Dear " + pp.StudentName + ". Your Embassy Fees is:" + pf.EmbassyFee + " and your Due Date Is : " + pf.EmbassyAlertDate + " Thanks and Regards " + of.CompanyName + "");

            }

            if (output == "Done")
            {
                this.SetNotification("Your Alert Message Send Sucessfully To " + pp.StudentName + "", NotificationEnumeration.Success);

            }
            else if (output == "SMS Not Activated")
            {
                this.SetNotification("SMS Sending Failed", NotificationEnumeration.Warning);
            }
            else
            {
                this.SetNotification("Message Not Send !", NotificationEnumeration.Error);

            }
           
            return RedirectToAction("Index");

        }
       


        // GET: Default/Delete/5
        public ActionResult CollegeAlert(int id)
        {
            DateTime NowDate = System.DateTime.Now;
            List<ProcessingForm> aa = new List<ProcessingForm>();
            dynamic model = new ExpandoObject();
            var data = (from t in db.ProcessingForms.Where(x => x.CollegeAlertDate <= NowDate)
                        join sc in db.PreForms on t.Formid equals sc.Preformid

                        select new { Studentid = sc.Preformid, Name = sc.StudentName, Father = sc.FatherName, Contact = sc.ContactNo, Fee = t.CollegeFee, AlertDate = t.CollegeAlertDate }).ToList();
            List<ExpandoObject> joinData = new List<ExpandoObject>();
            foreach (var item in data)
            {
                IDictionary<string, object> itemExpando = new ExpandoObject();
                foreach (PropertyDescriptor property
                         in
                         TypeDescriptor.GetProperties(item.GetType()))
                {
                    itemExpando.Add(property.Name, property.GetValue(item));
                }
                joinData.Add(itemExpando as ExpandoObject);
            }

            model.JoinData = joinData;
            return View(model);
        }
        public ActionResult GIC(int id)
        {
            DateTime NowDate = System.DateTime.Now;
            List<ProcessingForm> aa = new List<ProcessingForm>();
            dynamic model = new ExpandoObject();
            var data = (from t in db.ProcessingForms.Where(x => x.GICAlertDate <= NowDate)
                        join sc in db.PreForms on t.Formid equals sc.Preformid

                        select new { Studentid = sc.Preformid, Name = sc.StudentName, Father = sc.FatherName, Contact = sc.ContactNo, Fee = t.GICFee, AlertDate = t.GICAlertDate }).ToList();
            List<ExpandoObject> joinData = new List<ExpandoObject>();
            foreach (var item in data)
            {
                IDictionary<string, object> itemExpando = new ExpandoObject();
                foreach (PropertyDescriptor property
                         in
                         TypeDescriptor.GetProperties(item.GetType()))
                {
                    itemExpando.Add(property.Name, property.GetValue(item));
                }
                joinData.Add(itemExpando as ExpandoObject);
            }

            model.JoinData = joinData;
            return View(model);
        }
        public ActionResult Embassy(int id)
        {
            DateTime NowDate = System.DateTime.Now;
            List<ProcessingForm> aa = new List<ProcessingForm>();
            dynamic model = new ExpandoObject();
            var data = (from t in db.ProcessingForms.Where(x => x.EmbassyAlertDate <= NowDate)
                        join sc in db.PreForms on t.Formid equals sc.Preformid

                        select new { Studentid = sc.Preformid, Name = sc.StudentName, Father = sc.FatherName, Contact = sc.ContactNo, Fee = t.EmbassyFee, AlertDate = t.EmbassyAlertDate }).ToList();
            List<ExpandoObject> joinData = new List<ExpandoObject>();
            foreach (var item in data)
            {
                IDictionary<string, object> itemExpando = new ExpandoObject();
                foreach (PropertyDescriptor property
                         in
                         TypeDescriptor.GetProperties(item.GetType()))
                {
                    itemExpando.Add(property.Name, property.GetValue(item));
                }
                joinData.Add(itemExpando as ExpandoObject);
            }

            model.JoinData = joinData;
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

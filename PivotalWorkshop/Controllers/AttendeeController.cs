using PivotalWorkshop.DAL;
using PivotalWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PivotalWorkshop.Controllers
{
    public class AttendeeController : Controller
    {
        private AttendeeContext db = new AttendeeContext();

        // GET: Attendee
        public ViewResult Index()
        {
            Console.WriteLine("Getting ready to read the list of attendees");
            var attendees = from s in db.Attendees
                            select s;
            Console.WriteLine("Returning the list of attendees");
            return View(attendees);
        }

        // GET: Attendee Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("(Details) Attendee ID is missing");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                Console.WriteLine("(Details) Unable to locate Attendee {0} ", id);
                return HttpNotFound();
            }

            return View(attendee);
        }

        // : Create Attendee
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstName,lastName,email,phoneNumber")] Attendee attendee)
        {
            try
            {
                db.Attendees.Add(attendee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(RetryLimitExceededException dex)
            {
                Console.Error.WriteLine("An error occurred while saving a new attendee");
                Console.Error.WriteLine(dex.StackTrace);

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator");
            }

            return View(attendee);
        }

        // : Edit Attendee
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("(Edit) Attendee ID is missing");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                Console.WriteLine("(Edit) Unable to locate Attendee {0} ", id);
                return HttpNotFound();
            }

            return View(attendee);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("(EditPost) Attendee ID is missing");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var attendeeToUpdate = db.Attendees.Find(id);
            if (TryUpdateModel(attendeeToUpdate, "", new string[] { "firstName", "lastName", "email", "phoneNumber", "address", "city", "state", "zipCode" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(RetryLimitExceededException dex)
                {
                    Console.Error.WriteLine("An error occurred while saving an attendee");
                    Console.Error.WriteLine(dex.StackTrace);
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator");
                }
            }

            return View(attendeeToUpdate);
        }

        // GET: Delete Attendee 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("(Delete) Attendee ID is missing");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Attendee attendee = db.Attendees.Find(id);
            if (attendee == null)
            {
                Console.WriteLine("(Delete) Unable to locate Attendee {0} ", id);
                return HttpNotFound();
            }

            return View(attendee);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendee attendee = db.Attendees.Find(id);
            db.Attendees.Remove(attendee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
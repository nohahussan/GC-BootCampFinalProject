using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TextToSpeech.Models;

namespace TextToSpeech.Controllers
{
    public class LoginsController : Controller
    {        
        private TextToSpeechContext db = new TextToSpeechContext();

    // GET: Logins
    public ActionResult Index()
        {
            return View(db.Logins.ToList());
        }

        // GET: Logins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult ValidLogin(TextToSpeechContext logins)
        {
            if (logins == null)
            {
                ViewBag.ErrorMessage = "No users available!";
                return View("Error");
            }
            else
            {
                foreach (Login login in db.Logins)
                {
                    if (login.Email == login.Email && login.Password == login.Password)
                    {
                        Session["CurrentUser"] = login;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ViewBag.ErrorMessage = "Your Email address and/or password are not valid!";
            return View("Error");
        }

        public ActionResult RegisterUser(Login logins)
        {            
            if (Session["CurrentUser"] != null)
            {
                logins = (Login)Session["CurrentUser"];                
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {                    
                    Session["CurrentUser"] = logins;                    
                    db.Logins.Add(logins);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Registration Failed. Please try again";
                    return View("Create");
                }
            }
        }

        public ActionResult Logout()
        {            
            Session.Remove("CurrentUser");
            return RedirectToAction("Index", "Home");
        }
        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,Password,ConfirmPassword")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(login);
        }

        // GET: Logins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,Password,ConfirmPassword")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
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

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
    public class AudiosController : Controller
    {
        private TextToSpeechEntities db = new TextToSpeechEntities();

        // GET: Audios
        public ActionResult Index()
        {
            Login user = new Login();
            user = (Login)Session["CurrentUser"];
            var audios = db.Audios.Where(a => a.UserID == user.ID);
            return View(audios.ToList());
        }

        // GET: Audios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audio audio = db.Audios.Find(id);
            string lang = audio.Language;

            switch (lang)
            {
                case "English":
                    DAL.GetData(audio.Text, "en-us");
                    break;
                case "French":
                    DAL.GetData(audio.Text, "fr-fr");
                    break;
                case "German":
                    DAL.GetData(audio.Text, "de-de");
                    break;
                case "Spanish":
                    DAL.GetData(audio.Text, "es-mx");
                    break;
                default:
                    break;
            }
            if (audio == null)
            {
                return HttpNotFound();
            }
            return View(audio);
        }

        public ActionResult MyAudio()
        {
            var file = Server.MapPath("~/voice.mp3");
            return File(file, "audio/mp3");
        }

        // GET: Audios/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Logins, "ID", "FirstName");
            return View();
        }

        // POST: Audios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Text,Language,UserID")] Audio audio)
        {
            if (ModelState.IsValid)
            {
                db.Audios.Add(audio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Logins, "ID", "FirstName", audio.UserID);
            return View(audio);
        }

        public ActionResult Add()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Post obj = (Post)Session["a"];
                    Audio a = new Audio();
                    Login user = (Login)Session["CurrentUser"];
                    Login l = new Login();
                    a.Title = obj.Title;
                    a.Text = obj.Text;
                    a.Language = obj.Language;
                    a.UserID = user.ID;
                    Boolean find = false;
                    using (var context = db) //avoid any duplication in the database
                    {
                        // Load some posts from the database into the context                    
                        context.Audios.Load();
                        // Get the local collection 
                        var localPosts = context.Audios.Local;
                        // Loop over the posts in the context.
                        foreach (var post in localPosts)
                        {
                            if (post.Title == a.Title && post.Text == a.Text)
                            {
                                find = true;
                                break;
                            }
                        }

                        if (find == false)
                        {
                            db.Audios.Add(a);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        // GET: Audios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audio audio = db.Audios.Find(id);
            if (audio == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Logins, "ID", "FirstName", audio.UserID);
            return View(audio);
        }

        // POST: Audios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Text,Language,UserID")] Audio audio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Logins, "ID", "FirstName", audio.UserID);
            return View(audio);
        }

        // GET: Audios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audio audio = db.Audios.Find(id);
            if (audio == null)
            {
                return HttpNotFound();
            }
            return View(audio);
        }

        // POST: Audios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audio audio = db.Audios.Find(id);
            db.Audios.Remove(audio);
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

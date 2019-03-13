using TextToSpeech.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VoiceRSS_SDK;
using System.ComponentModel;

namespace TextToSpeech.Controllers
{
    public class HomeController : Controller
    {
        Post obj = new Post();
        Post userChoice = new Post();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Spanish()
        {
            return View(obj.Text);
        }
        [HttpPost]
        public ActionResult Spanish(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.Spanish_Mexico);
            }
            // return RedirectToAction("MyAudio");
            return View();
        }
        public ActionResult German()
        {
            return View(obj.Text);
        }
        [HttpPost]
        public ActionResult German(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.German);
            }
            //return RedirectToAction("MyAudio");
            return View();
        }
        public ActionResult English()
        {
           // Post obj = new Post();
            
            return View(obj.Text);
            
        }
        [HttpPost]
        public ActionResult English(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.English_UnitedStates);
            }
            return View();
            // return RedirectToAction("MyAudio");
        }
        public ActionResult French()
        {
            return View(obj.Text);
        }
        [HttpPost]
        public ActionResult French(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.French_France);
            }
            // return RedirectToAction("MyAudio");
            return View();
        }

        public ActionResult MyAudio()
        {
            var file = Server.MapPath("~/voice.mp3");
            return File(file, "audio/mp3");   
                      
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Post obj)
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
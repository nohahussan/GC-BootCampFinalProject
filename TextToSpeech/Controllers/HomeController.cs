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
        Post userChoice = new Post();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mexico()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Mexico(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.Spanish_Mexico);
            }
            return RedirectToAction("MyAudio");
        }
        public ActionResult German()
        {
            return View();
        }
        [HttpPost]
        public ActionResult German(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.German);
            }
            return RedirectToAction("MyAudio");
        }
        public ActionResult English()
        {
            return View();
        }
        [HttpPost]
        public ActionResult English(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.English_UnitedStates);
            }
            return RedirectToAction("MyAudio");
        }
        public ActionResult French()
        {
            return View();
        }
        [HttpPost]
        public ActionResult French(Post obj)
        {
            if (ModelState.IsValid)
            {
                DAL.GetData(obj.Text, Languages.French_France);
            }
            return RedirectToAction("MyAudio");
        }

        public ActionResult MyAudio()
        {
            var file = Server.MapPath("~/voice.mp3");
            return File(file, "audio/mp3");            
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
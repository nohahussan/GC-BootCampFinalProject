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
        public ActionResult MyAudio()
        {
            var file = Server.MapPath("~/voice.mp3");
            return File(file, "audio/mp3");
            
        }
        [HttpPost]
        public ActionResult Index(Post obj)
        {
            if (ModelState.IsValid)
            {
                 DAL.GetData(obj.Text);
            }
            return RedirectToAction("MyAudio"); 
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
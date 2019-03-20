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
            Session["a"] = obj;
            if (obj.Language == null)
            {
                obj.Language = "Spanish";//this to store the language field to the data base 
                return View();

            }
            else
            {
                return RedirectToAction("Translation");
            }
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
            Session["a"] = obj;
            if (obj.Language == null)
            {
                obj.Language = "German";//this to store the language field to the data base 
                return View();

            }
            else
            {
                return RedirectToAction("Translation");
            }
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
            
            Session["a"] = obj;
            if (obj.Language == null)
            {
                obj.Language = "English";//this to store the language field to the data base 
                return View();
            }
            else
            {
                return RedirectToAction("Translation");
            }
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
            Session["a"] = obj;
            if (obj.Language == null)
            {
                obj.Language = "French";//this to store the language field to the data base 
                return View();
            }
            
            else
            {
                return RedirectToAction("Translation");
            }
        }

        public ActionResult ErrorLanguage()
        {
            return View();
        }

        public ActionResult Translation()
        {
            Post var = (Post)Session["a"];
            string lang = var.Language.Trim(' ').ToLower();

            switch (lang)
            {               
                case "ingles":
                case "anglais":
                case "englisch":
                    TranslatePost enObj = TranslateDAL.GetPost(var.Text, "en");
                    DAL.GetData(enObj.TranslatedText, Languages.English_UnitedStates);
                    return View(enObj);
                case "spanish":
                case "espagnol":
                case "spanisch":  
                    TranslatePost spObj = TranslateDAL.GetPost(var.Text, "es");
                    DAL.GetData(spObj.TranslatedText, Languages.Spanish_Mexico);
                    return View(spObj);
                case "french":
                case "frances":
                case "franzosisch":
                    TranslatePost frObj = TranslateDAL.GetPost(var.Text, "fr");
                    DAL.GetData(frObj.TranslatedText, Languages.French_France);
                    return View(frObj);
                case "german":
                case "aleman":
                case "allemand":
                    TranslatePost grObj = TranslateDAL.GetPost(var.Text, "de");
                    DAL.GetData(grObj.TranslatedText, Languages.German);
                    return View(grObj);
                default:
                    return RedirectToAction("ErrorLanguage");
            }           
        }
        
        public ActionResult MyAudio()
        {
            var file = Server.MapPath("~/voice.mp3");
            return File(file, "audio/mp3");                      
        }

        public ActionResult Save()
        {
            AudiosController audio = new AudiosController();
            return View("Create", audio);
        }

        public ActionResult Login()
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
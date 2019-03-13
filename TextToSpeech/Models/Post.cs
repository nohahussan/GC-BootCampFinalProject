using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TextToSpeech.Models
{
    public class Post
    {
        public string Text { get; set; }

        public Post()
        { }

        public Post(string Text)
        {
           this.Text = Text;
        }


    }
}
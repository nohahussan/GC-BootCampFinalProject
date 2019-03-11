using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TextToSpeech.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }

        public Post()
        { }

        public Post(string Text)
        {
           this.Text = Text;
        }
    }
}
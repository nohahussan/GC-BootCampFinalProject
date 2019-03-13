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
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public Post()
        { }

        public Post(string Text)
        {
           this.Text = Text;
        }
    }
}
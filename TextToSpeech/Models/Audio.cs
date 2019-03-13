using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextToSpeech.Models
{
    public class Audio
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
        public string Language { get; set; }

        public Audio()
        {

        }

        public Audio(int id, string title, string file, string language)
        {
            ID = id;
            Title = title;
            File = file;
            Language = language;

        }
    }
}
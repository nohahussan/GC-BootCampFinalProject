using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TextToSpeech.Models
{
    public class Audio
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public string Language { get; set; }

        public Audio()
        {

        }

        public Audio(int id, string title, string text, string language)
        {
            ID = id;
            Title = title;
            Text = text;
            Language = language;
        }
    }

    //public class TextToSpeechContext : DbContext
    //{
    //    public DbSet<Audio> Audios { get; set; }
    //}
}
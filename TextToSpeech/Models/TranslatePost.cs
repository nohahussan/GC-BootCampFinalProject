using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TextToSpeech.Models
{
    public class TranslatePost
    {
        public string TranslatedText { get; set; }
        
        public TranslatePost()
        {

        }
        
        public TranslatePost(string APIText)
        {
            JObject redditJson = JObject.Parse(APIText);

            JToken post = redditJson["text"];

            TranslatedText = post.ToString();

            List<JToken> posts = redditJson["text"].ToList();
            
            TranslatedText = posts[0].ToString();
        }
    }
}
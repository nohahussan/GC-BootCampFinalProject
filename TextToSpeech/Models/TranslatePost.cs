using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace translation_API.Models
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
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;


namespace TextToSpeech.Models
{
    public class TranslateDAL
    {
        public static string GetData(string Url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(Url);


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();

            return data;
        }

        public static TranslatePost GetPost(string text, String lang)
        {

            string apiKey = "trnsl.1.1.20190318T141637Z.e8bd158c11dffe67.a50201f1b610d3880500bcacbada3d7227e59a3e";

            string output = GetData($"https://translate.yandex.net/api/v1.5/tr.json/translate?key="+apiKey+"&text="+text+"&lang="+lang);
            TranslatePost rp = new TranslatePost(output);

            return rp;
        }
    }
}



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VoiceRSS_SDK;

namespace TextToSpeech.Models
{
    public class DAL
    {
        public static void GetData(string Text,string lang)
        {
            var apiKey = "8251658e18e14a7eb81d4366a62ee4bf";
            var isSSL = false;
            //var lang = Languages.English_UnitedStates;
            
            var voiceParams = new VoiceParameters(Text, lang)
            {
                AudioCodec = AudioCodec.MP3,
                AudioFormat = AudioFormat.Format_44KHZ.AF_44khz_16bit_stereo,
                IsBase64 = false,
                IsSsml = false,
                SpeedRate = 0
            };

            var voiceProvider = new VoiceProvider(apiKey, isSSL);
            var voice = voiceProvider.Speech<byte[]>(voiceParams);
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "voice.mp3");
            File.WriteAllBytes(fileName, voice);
        }
    }
}
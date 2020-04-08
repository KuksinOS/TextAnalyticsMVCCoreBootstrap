using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyticsMVCCoreBootstrap.Models;
using TextAnalyticsMVCCoreBootstrap.MostFrequentChars;
using Google.Cloud.Language.V1;
using LanguageDetection;
using NUnit.Framework;

namespace TextAnalyticsMVCCoreBootstrap.Algoritm
{
    public class DetectLanguage<T> : IAlgoritm<AnswerModel<string>>
    {


        public AnswerModel<string> Execute(string text)
        {
            AnswerModel<string> answer = new AnswerModel<string>();
            LanguageDetector detector = new LanguageDetector();
            detector.AddAllLanguages();
            Assert.AreEqual("lv", detector.Detect("Привет"));


            answer.Property = "Определен язык: ";
            answer.Value = "Определен язык: ";

            return answer;
        }



        public AnswerModel<string> ExecuteFromGoogle(string text)
        {
            AnswerModel<string> answer = new AnswerModel<string>();

            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "Path to Your API Key");

            var client = LanguageServiceClient.Create();
            Document document = Document.FromPlainText(text);
            AnalyzeSentimentResponse response = client.AnalyzeSentiment(document);
            
            answer.Property = "Определен язык: ";
            answer.Value = response.Language;

            return answer;
        }






    }
}

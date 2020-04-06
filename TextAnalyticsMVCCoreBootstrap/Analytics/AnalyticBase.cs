using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyticsMVCCoreBootstrap.Models;
using TextAnalyticsMVCCoreBootstrap.MostFrequentChars;

namespace TextAnalyticsMVCCoreBootstrap.Analytics
{
    public abstract class AnalyticBase<T>
    {
        public T Execute(IAlgoritm<T> algoritm, string text)
        {
           return algoritm.Execute(text);
        }

        public abstract string Display(string result);
    }
}

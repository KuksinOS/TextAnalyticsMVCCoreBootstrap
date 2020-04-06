using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyticsMVCCoreBootstrap.Models;

namespace TextAnalyticsMVCCoreBootstrap.MostFrequentChars
{
    public interface IAlgoritm<out T>
    {
        T Execute(string text);
    }
}

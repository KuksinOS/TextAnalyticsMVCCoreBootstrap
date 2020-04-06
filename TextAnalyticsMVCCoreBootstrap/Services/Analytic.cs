using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextAnalyticsMVCCoreBootstrap.Analytics;

namespace TextAnalyticsMVCCoreBootstrap.Services
{
    public class Analytic<T> : AnalyticBase<T>
    {
        public override string Display(string result)
        {
            return result;
        }
    }
}

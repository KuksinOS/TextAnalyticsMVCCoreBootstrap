using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAnalyticsMVCCoreBootstrap.Models
{
    public class AnswerModel<T>
    {
        //  public int Id { get; set; }
        //  public int QuestionId { get; set; }
        public string Property { get; set; }
        public T Value { get; set; }
    }
}

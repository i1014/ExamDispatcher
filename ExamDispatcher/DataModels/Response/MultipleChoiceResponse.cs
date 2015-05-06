using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Questions;

namespace DataModels.Response
{
    public class MultipleChoiceResponse
    {
        public string Question { get; set; }
        public Guid QuestionGuid { get; set; }
        public List<string> Options { get; set; }
        public QuestionType Type { get; set; }

        public MultipleChoiceResponse()
        {
        }

        public MultipleChoiceResponse(string question, Guid questionGuid, List<string> options, QuestionType type)
        {
            Question = question;
            QuestionGuid = questionGuid;
            Options = options;
            Type = type;
        }
    }
}

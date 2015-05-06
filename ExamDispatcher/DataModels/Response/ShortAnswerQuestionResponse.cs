using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataModels.Questions;

namespace DataModels.Response
{
    public class ShortAnswerQuestionResponse
    {
        public string Question { get; set; }
        public Guid QuestionGuid { get; set; }
        public QuestionType Type { get; set; }

        public ShortAnswerQuestionResponse()
        {
        }

        public ShortAnswerQuestionResponse(string question, Guid questionGuid, QuestionType type)
        {
            Question = question;
            QuestionGuid = questionGuid;
            Type = type;
        }
    }
}

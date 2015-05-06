using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Questions;

namespace DataModels.Response
{
    public class MatchingQuestionResponse
    {
        public string Question { get; set; }
        public Guid QuestionGuid { get; set; }
        public List<string> Choices { get; set; }
        public List<string> Answers { get; set; } 
        public QuestionType Type { get; set; }

        public MatchingQuestionResponse()
        {
        }

        public MatchingQuestionResponse(string question, Guid questionGuid, List<string> choices, List<string> answers, QuestionType type)
        {
            Question = question;
            QuestionGuid = questionGuid;
            Choices = choices;
            Answers = answers;
            Type = type;
        }
    }
}

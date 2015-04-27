using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels.Questions;

namespace DataModels
{
    public class Answer
    {
        public Guid QuestionGuid { get; private set; }
        public QuestionType Type { get; private set; }
        public object StudentAnswer { get; private set; }

        public Answer()
        {
            
        }

        public Answer(Guid questionGuid, QuestionType type, object studentAnswer)
        {
            QuestionGuid = questionGuid;
            Type = type;
            StudentAnswer = studentAnswer;
        }
    }
}

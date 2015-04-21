
using System;

namespace DataModels
{
    public class ShortAnswerQuestion : BaseQuestion
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public QuestionType Type { get; private set; }

        public ShortAnswerQuestion()
        {
            Question = "";
            Answer = "";
            Type = QuestionType.ShortAnswer;
        }

        public ShortAnswerQuestion(string question, string answer)
        {
            Question = question;
            Answer = answer;
            Type = QuestionType.ShortAnswer;
        }

        public string GetQuestionToString()
        {
            return Question;
        }
    }
}


using System;

namespace DataModels.Questions
{
    [Serializable]
    public class ShortAnswerQuestion : BaseQuestion
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }

        public ShortAnswerQuestion()
        {
            Question = "";
            QuestionGuid = Guid.NewGuid();
            Answer = "";
            Type = QuestionType.ShortAnswer;
        }

        public ShortAnswerQuestion(string question, Guid questionGuid, string answer)
        {
            Question = question;
            QuestionGuid = questionGuid;
            Answer = answer;
            Type = QuestionType.ShortAnswer;
        }

        public string GetQuestionToString()
        {
            return Question;
        }
    }
}

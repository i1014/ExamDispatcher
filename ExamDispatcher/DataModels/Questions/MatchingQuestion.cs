using System;
using System.Collections.Generic;

namespace DataModels.Questions
{
    [Serializable]
    public class MatchingQuestion : BaseQuestion
    {
        public string Question { get; private set; }
        public Guid QuestionGuid { get; private set; }
        public List<string> OptionsList { get; private set; }
        public string Answer { get; private set; }
        public QuestionType Type { get; private set; }

        public MatchingQuestion()
        {
            Question = "";
            QuestionGuid = Guid.NewGuid();
            OptionsList = new List<string>();
            Answer = "";
            Type = QuestionType.Matching;
        }

        public MatchingQuestion(string question, Guid questionGuid, List<string> optionsList, string answer)
        {
            Question = question;
            QuestionGuid = questionGuid;
            OptionsList = optionsList;
            Answer = answer;
            Type = QuestionType.Matching;
        }

        public string GetQuestionToString()
        {
            return Question;
        }
    }
}

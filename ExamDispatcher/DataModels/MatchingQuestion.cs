using System;
using System.Collections.Generic;

namespace DataModels
{
    [Serializable]
    public class MatchingQuestion : BaseQuestion
    {
        public string Question { get; private set; }
        public List<string> OptionsList { get; private set; }
        public string Answer { get; private set; }
        public QuestionType Type { get; private set; }

        public MatchingQuestion()
        {
            Question = "";
            OptionsList = new List<string>();
            Answer = "";
            Type = QuestionType.Matching;
        }

        public MatchingQuestion(string question, List<string> optionsList, string answer)
        {
            Question = question;
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

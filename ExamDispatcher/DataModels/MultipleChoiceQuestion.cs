
using System;
using System.Collections.Generic;

namespace DataModels
{
    [Serializable]
    public class MultipleChoiceQuestion : BaseQuestion
    {
        public string Question { get; private set; }
        public List<MultipleChoiceOption> Options { get; private set; } 
        public string Answer { get; private set; }
        public QuestionType Type { get; private set; }

        public MultipleChoiceQuestion()
        {
            Question = "";
            Answer = "";
            Options = new List<MultipleChoiceOption>();
            Type = QuestionType.MultipleChoice;
        }

        public MultipleChoiceQuestion(string question, string answer, List<MultipleChoiceOption> optionList )
        {
            Options = optionList;
            Question = question;
            Answer = answer;
            Type = QuestionType.MultipleChoice;
        }

        public string GetQuestionToString()
        {
            return Question;
        }
    }
}

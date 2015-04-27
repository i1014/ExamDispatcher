
using System;
using System.Collections.Generic;

namespace DataModels.Questions
{
    [Serializable]
    public class MultipleChoiceQuestion : BaseQuestion
    {
        public string Question { get; private set; }
        public Guid QuestionGuid { get; private set; }
        public List<MultipleChoiceOption> Options { get; private set; } 
        public string Answer { get; private set; }
        public QuestionType Type { get; private set; }

        public MultipleChoiceQuestion()
        {
            Question = "";
            QuestionGuid = Guid.NewGuid();
            Answer = "";
            Options = new List<MultipleChoiceOption>();
            Type = QuestionType.MultipleChoice;
        }

        public MultipleChoiceQuestion(string question, Guid questionGuid, string answer, List<MultipleChoiceOption> optionList )
        {
            Options = optionList;
            QuestionGuid = QuestionGuid;
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

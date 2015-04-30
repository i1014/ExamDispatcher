
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
        public string SuggestedAnswer { get; private set; }
        public QuestionType Type { get; private set; }

        public MultipleChoiceQuestion()
        {
            Question = "";
            QuestionGuid = Guid.NewGuid();
            SuggestedAnswer = "";
            Options = new List<MultipleChoiceOption>();
            Type = QuestionType.MultipleChoice;
        }

        public MultipleChoiceQuestion(string question, Guid questionGuid, string suggestedAnswer, List<MultipleChoiceOption> optionList )
        {
            Options = optionList;
            QuestionGuid = questionGuid;
            Question = question;
            SuggestedAnswer = suggestedAnswer;
            Type = QuestionType.MultipleChoice;
        }

        public string GetQuestionToString()
        {
            return Question;
        }
    }
}

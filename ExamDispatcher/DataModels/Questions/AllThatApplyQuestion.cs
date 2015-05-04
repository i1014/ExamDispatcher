using System;
using System.Collections.Generic;

namespace DataModels.Questions
{
    [Serializable]
    public class AllThatApplyQuestion : BaseQuestion
    {
        public string Question { get; private set; }
        public List<string> OptionsList { get; private set; }
        public List<string> AnswerList { get; private set; }

        public AllThatApplyQuestion()
        {
            Question = "";
            OptionsList = new List<string>();
            AnswerList = new List<string>();
            Type = QuestionType.AllThatApply;
        }

        public AllThatApplyQuestion(string question, List<string> optionsList, List<string> answerList)
        {
            Question = question;
            OptionsList = optionsList;
            AnswerList = answerList;
            Type = QuestionType.AllThatApply;
        }

        public string GetQuestionToString()
        {
            return Question;
        }
    }
}

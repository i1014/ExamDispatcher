using System.Collections.Generic;

namespace DataModels
{
    public class AllThatApplyQuestion : Question
    {
        public string Question { get; private set; }
        public List<string> OptionsList { get; private set; }
        public List<string> AnswerList { get; private set; }
        public QuestionType Type { get; private set; }

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
    }
}

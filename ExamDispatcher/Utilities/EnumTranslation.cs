using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Questions;

namespace Utilities
{
    public static class EnumTranslation
    {
        public static QuestionType EnumFromType(BaseQuestion question)
        {
            var type = question.GetType().ToString();

            if (type.Equals("DataModels.Questions.ShortAnswerQuestion"))
                return QuestionType.ShortAnswer;

            if (type.Equals("DataModels.Questions.MultipleChoiceQuestion"))
                return QuestionType.MultipleChoice;

            if (type.Equals("DataModels.Questions.MatchingQuestion"))
                return QuestionType.Matching;

            if (type.Equals("DataModels.Questions.AllThatApplyQuestion"))
                return QuestionType.AllThatApply;

            //TODO This is incorrect.
            if (type.Equals("DataModels.Questions.TrueFalse"))
                return QuestionType.FillInTheBlank;

            return QuestionType.Matching;
        }
    }
}

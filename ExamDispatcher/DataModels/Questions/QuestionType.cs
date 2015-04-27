
using System;

namespace DataModels.Questions
{
    [Serializable]
    public enum QuestionType
    {
        MultipleChoice,
        ShortAnswer,
        FillInTheBlank,
        Matching,
        AllThatApply
    }
}

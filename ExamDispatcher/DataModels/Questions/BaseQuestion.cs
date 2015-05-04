using System;

namespace DataModels.Questions
{
    [Serializable]
    public class BaseQuestion
    {
        public QuestionType Type { get; set; }

        public Guid QuestionGuid { get; internal set; }
    }
}

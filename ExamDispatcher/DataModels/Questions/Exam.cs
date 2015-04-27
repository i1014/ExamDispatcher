using System;
using System.Collections.Generic;

namespace DataModels.Questions
{
    [Serializable]
    public class Exam
    {
        public string ExamTitle { get; private set; }
        public Guid ExamId { get; private set; }
        public List<BaseQuestion> QuestionList { get; private set; }

        public Exam()
        {
            ExamTitle = "";
            QuestionList = new List<BaseQuestion>();
            ExamId = Guid.NewGuid();
        }

        public Exam(string examTitle, Guid examId, List<BaseQuestion> questionList)
        {
            ExamTitle = examTitle;
            ExamId = examId;
            QuestionList = questionList;
        }
    }
}

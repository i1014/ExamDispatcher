using System;
using System.Collections.Generic;

namespace DataModels.Questions
{
    [Serializable]
    public class Exam
    {
        public string ExamTitle { get; private set; }
        public Guid ExamId { get; private set; }
        public int Minutes { get; private set; }
        public List<BaseQuestion> QuestionList { get; private set; }

        public Exam()
        {
            ExamTitle = "";
            QuestionList = new List<BaseQuestion>();
            ExamId = Guid.NewGuid();
            Minutes = 0;
        }

        public Exam(string examTitle, Guid examId, List<BaseQuestion> questionList, int minutes)
        {
            ExamTitle = examTitle;
            ExamId = examId;
            Minutes = minutes;
            QuestionList = questionList;
        }
    }
}

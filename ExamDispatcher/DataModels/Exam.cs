using System;
using System.Collections.Generic;

namespace DataModels
{
    public class Exam
    {
        public string ExamTitle { get; private set; }
        public Guid ExamId { get; private set; }
        public List<Question> QuestionList { get; private set; }

        public Exam()
        {
            ExamTitle = "";
            QuestionList = new List<Question>();
            ExamId = Guid.NewGuid();
        }

        public Exam(string examTitle, Guid examId, List<Question> questionList)
        {
            ExamTitle = examTitle;
            ExamId = examId;
            QuestionList = questionList;
        }
    }
}

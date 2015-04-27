using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModels.Questions;

namespace DataModels
{
    public class ExamResult
    {
        public Guid TeamIdGuid { get; set; }
        public Guid ExamGuid { get; set; }
        public Exam Exam { get; set; }
        public IList<Answer> Answers { get; set; }

        public ExamResult(Guid teamIdGuid, Guid examGuid, Exam exam, IList<Answer> answers)
        {
            TeamIdGuid = teamIdGuid;
            ExamGuid = examGuid;
            Exam = exam;
            Answers = answers;
        }
    }
}

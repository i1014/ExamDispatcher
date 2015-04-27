using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModels.Request
{
    public class SubmitAnswersRequest
    {
        public Guid ExamGuid { get; private set; }
        public Guid TeamGuid { get; private set; }
        public IList<Answer> Answers { get; private set; }

        public SubmitAnswersRequest(Guid examGuid, Guid teamGuid, IList<Answer> answers)
        {
            ExamGuid = examGuid;
            TeamGuid = teamGuid;
            Answers = answers;
        }

        public SubmitAnswersRequest()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Questions;

namespace DataModels.Response
{
    public class ExamResponse
    {
        public string ExamTitle { get; private set; }
        public Guid ExamGuid { get; private set; }
        public long TestDuration { get; private set; }
        public List<ShortAnswerQuestionResponse> ShortAnswerQuestions { get; private set; }
        public List<MultipleChoiceResponse> MultipleChoiceQuestions { get; private set; }
        public List<MatchingQuestionResponse> MatchingQuestions { get; private set; }

        public ExamResponse()
        {
        }

        public ExamResponse(string examTitle, Guid examGuid, long testDuration, List<ShortAnswerQuestionResponse> shortAnswerQuestions, List<MultipleChoiceResponse> multipleChoiceQuestions, List<MatchingQuestionResponse> matchingQuestions)
        {
            ExamTitle = examTitle;
            ExamGuid = examGuid;
            TestDuration = testDuration;
            ShortAnswerQuestions = shortAnswerQuestions;
            MultipleChoiceQuestions = multipleChoiceQuestions;
            MatchingQuestions = matchingQuestions;
        }
    }
}

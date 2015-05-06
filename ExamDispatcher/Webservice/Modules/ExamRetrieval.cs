using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;
using DataModels.Questions;
using DataModels.Response;
using ExamSandbox;

namespace Webservice.Modules
{
    public class ExamRetrieval : NancyModule
    {
        public ExamRetrieval() : base("/MDX")
        {
            Get["/ExamRetrieval/{testId}"] = _ =>
            {
                var exam = GetExam(new Guid(_.testId));
                
                var mcList = exam.QuestionList.Where(x => x.Type == QuestionType.MultipleChoice);
                var mcResList = new List<MultipleChoiceResponse>();
                foreach (var question in mcList)
                {
                    var q = question as MultipleChoiceQuestion;
                    mcResList.Add(new MultipleChoiceResponse(q.Question, q.QuestionGuid, q.Options.Select(x => x.Option).ToList(), q.Type));
                }

                var saList = exam.QuestionList.Where(x => x.Type == QuestionType.ShortAnswer);
                var saResList = new List<ShortAnswerQuestionResponse>();
                foreach (var question in saList)
                {
                    var q = question as ShortAnswerQuestion;
                    saResList.Add(new ShortAnswerQuestionResponse(q.Question, q.QuestionGuid, q.Type));
                }

                var maList = exam.QuestionList.Where(x => x.Type == QuestionType.Matching);
                var maResList = new List<MatchingQuestionResponse>();
                foreach (var question in maList)
                {
                    var q = question as MatchingQuestion;
                    //maResList.Add(new MatchingQuestionResponse(q.Question, q.QuestionGuid, q.Type));
                }

                long time = exam.Minutes*1000*60;


                var res = new ExamResponse(exam.ExamTitle, exam.ExamId, time, saResList, mcResList, maResList);

                return Response.AsJson(res);
            };

            Get["/ExamRetrieval"] = _ =>
            {
                var id = this.Bind<Guid>();

                return Response.AsJson(GetExam(id));
            };

            Get["/ExamRetrieval/Partial"] = _ =>
            {

                //TODO I'm dot sure what to return for a partial test.
                return null;
            };
        }

        private Exam GetExam(Guid id)
        {
            var exam = Sandbox.GetActiveExamById(id);

            return exam;
        }

    }
}

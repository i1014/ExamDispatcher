using System;
using Nancy;
using Nancy.ModelBinding;
using DataModels.Questions;
using ExamSandbox;

namespace Webservice.Modules
{
    public class ExamRetrieval : NancyModule
    {
        public ExamRetrieval() : base("/MDX")
        {
            Get["/ExamRetrieval/{testId}"] = _ =>
            {
                return Response.AsJson(GetExam(new Guid(_.testId)));
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

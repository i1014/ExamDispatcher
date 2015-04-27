using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.ModelBinding;
using DataModels;
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
                return null;
            };
        }

        private Exam GetExam(Guid id)
        {
            var exam = Sandbox.GetExamById(id);

            return exam;
        }

    }
}

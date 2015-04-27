using DataModels.Request;
using ExamSandbox;
using Nancy;
using Nancy.ModelBinding;

namespace Webservice.Modules
{
    public class ExamSubmission : NancyModule
    {
        public ExamSubmission()
            : base("/MDX")
        {
            Post["/ExamSubmittion"] = _ =>
            {
                var x = this.Bind<SubmitAnswersRequest>();

                Washbin.SubmitAnswers(x.Answers, x.ExamGuid, x.TeamGuid);

                return null;
            };
        }


    }
}

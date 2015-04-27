using System;
using System.Collections.Generic;
using System.Linq;
using DataModels;

namespace ExamSandbox
{
    public static class Washbin
    {
        private static IList<ExamResult> Results;

        static Washbin()
        {
            Results = new List<ExamResult>();
        }

        public static IList<ExamResult> GetResultByTeamId(Guid teamGuid)
        {
            var res = Results.Where(x => x.TeamIdGuid.Equals(teamGuid));

            return res.Any() ? res.ToList() : null;
        }

        public static ExamResult GetResultByTeamAndExamId(Guid examGuid, Guid teamGuid)
        {
            var res = Results.Where(x => x.ExamGuid.Equals(examGuid) && x.TeamIdGuid.Equals(teamGuid));

            return res.Any() ? res.First() : null;
        }

        public static void SubmitAnswers(IList<Answer> answers, Guid examGuid, Guid teamGuid)
        {
            //Check to see if it exists.
            if (GetResultByTeamAndExamId(examGuid, teamGuid) == null)
                CreateNewExamResult(examGuid, teamGuid);

            //Once it exists add the answers.
            AddToExistingExamResult(answers, examGuid, teamGuid);
        }

        private static void CreateNewExamResult(Guid examGuid, Guid teamGuid)
        {
            //Get the raw exam.
            var exam = Sandbox.GetActiveExamById(examGuid);

            //Create the empty exam result.
            var toAdd = new ExamResult(teamGuid, examGuid, exam, new List<Answer>());

            //Add the result to the list.
            Results.Add(toAdd);
        }

        private static void AddToExistingExamResult(IList<Answer> answers, Guid examGuid, Guid teamGuid)
        {
            //Find the active exam result.
            var examResult = GetResultByTeamAndExamId(examGuid, teamGuid);

            //Find it's location in the list.
            var index = Results.IndexOf(examResult);

            //Add each to the list.
            foreach (var ans in answers.ToList())
            {
                var res = examResult.Answers.Where(x => x.QuestionGuid.Equals(ans.QuestionGuid));

                //Remove any previous iterations of the question being added.
                foreach (var r in res.ToList())
                {
                    examResult.Answers.Remove(r);
                }

                //Add the question
                examResult.Answers.Add(ans);
            }

            //Update the object in the list.
            Results[index] = examResult;
        }
    }
}

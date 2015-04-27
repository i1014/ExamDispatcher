using System;
using ExamSandbox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebserviceTest
{
    [TestClass]
    public class ExamWashbinTest
    {
        [TestMethod]
        public void TestCreateNewExamResult()
        {
            var mock = new MockData();
            var teamGuid = Guid.NewGuid();
            var examGuid = Guid.NewGuid();

            Washbin.SubmitAnswers(mock.GetMockAnswers(), examGuid, teamGuid);

            Assert.IsNotNull(Washbin.GetResultByTeamAndExamId(examGuid, teamGuid));
        }

        [TestMethod]
        public void TestAddToExistingExamResultsAddsQuestions()
        {
            var mock = new MockData();
            var teamGuid = Guid.NewGuid();
            var examGuid = Guid.NewGuid();

            var list1 = mock.GetMockAnswers();
            var list2 = mock.GetMockAnswers();

            Washbin.SubmitAnswers(list1, examGuid, teamGuid);
            Washbin.SubmitAnswers(list2, examGuid, teamGuid);

            Assert.IsTrue(Washbin.GetResultByTeamAndExamId(examGuid, teamGuid).Answers.Count == 20);
        }

        [TestMethod]
        public void TestAddToExistingExamResultsDoesntDuplicateQuestions()
        {
            var mock = new MockData();
            var teamGuid = Guid.NewGuid();
            var examGuid = Guid.NewGuid();

            var list1 = mock.GetMockAnswers();
            var list2 = mock.GetMockAnswers();
            var combinedList = list1;

            foreach (var answer in list2)
            {
                combinedList.Add(answer);
            }

            Washbin.SubmitAnswers(list1, examGuid, teamGuid);
            Washbin.SubmitAnswers(list2, examGuid, teamGuid);
            Washbin.SubmitAnswers(combinedList, examGuid, teamGuid);

            Assert.IsTrue(Washbin.GetResultByTeamAndExamId(examGuid, teamGuid).Answers.Count == 20);
        }
    }
}

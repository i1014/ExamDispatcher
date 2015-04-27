using System;
using System.Collections.Generic;
using DataModels.Questions;
using ExamSandbox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebserviceTest
{
    [TestClass]
    public class ExamSandboxTest
    {
        [TestMethod]
        public void TestAddExamToSandbox()
        {
            var guid = new Guid("e28b7426-c328-49fc-b3c2-e9f225b534e9");
            var exam = new Exam("Title", guid, new List<BaseQuestion>());

            Sandbox.AddExamToSandbox(exam);

            Assert.IsNotNull(Sandbox.GetExamById(guid));
        }

        [TestMethod]
        public void TestRemoveExam()
        {
            var guid = new Guid("e28b7426-c328-49fc-b3c2-e9f225b534e9");
            var exam = new Exam("Title", guid, new List<BaseQuestion>());

            Sandbox.AddExamToSandbox(exam);

            Sandbox.RemoveExamById(guid);

            Assert.IsNull(Sandbox.GetExamById(guid));
        }

        [TestMethod]
        public void TestStartExam()
        {
            var guid = new Guid("e28b7426-c328-49fc-b3c2-e9f225b534e9");
            var exam = new Exam("Title", guid, new List<BaseQuestion>());

            Sandbox.AddExamToSandbox(exam);

            Sandbox.StartExamById(guid);

            Assert.IsNotNull(Sandbox.GetActiveExamById(guid));
        }

        [TestMethod]
        public void TestStopExam()
        {
            var guid = new Guid("e28b7426-c328-49fc-b3c2-e9f225b534e9");
            var exam = new Exam("Title", guid, new List<BaseQuestion>());

            Sandbox.AddExamToSandbox(exam);

            Sandbox.StartExamById(guid);
            Sandbox.StopExamById(guid);

            Assert.IsNull(Sandbox.GetActiveExamById(guid));
        }

        [TestMethod]
        public void TestGetActiveExams()
        {
            var guid = new Guid("e28b7426-c328-49fc-b3c2-e9f225b534e9");
            var exam = new Exam("Title", guid, new List<BaseQuestion>());

            Sandbox.AddExamToSandbox(exam);

            Sandbox.StartExamById(guid);

            Assert.IsTrue((Sandbox.GetActiveExams().Count > 0));
        }

        [TestMethod]
        public void TestGetAvailableExams()
        {
            var guid = new Guid("e28b7426-c328-49fc-b3c2-e9f225b534e9");
            var exam = new Exam("Title", guid, new List<BaseQuestion>());

            Sandbox.AddExamToSandbox(exam);

            Assert.IsTrue((Sandbox.GetAvailableExams().Count > 0));
        }


    }
}

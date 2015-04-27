using System;
using System.Collections.Generic;
using System.Linq;
using DataModels.Questions;

namespace ExamSandbox
{
    public static class Sandbox
    {
        private static IList<Exam> Exams;
        private static IList<Exam> ActiveExams;

        static Sandbox()
        {
            Exams = new List<Exam>();
            ActiveExams = new List<Exam>();
        }

        public static void AddExamToSandbox(Exam exam)
        {
            Exams.Add(exam);
        }

        public static void StartExamById(Guid id)
        {
            var ex = Exams.Where(x => x.ExamId.Equals(id));

            if (ex.ToArray().Length != 0)
            {
                foreach (var index in ex.ToList())
                {
                    ActiveExams.Add(index);
                    Exams.Remove(index);
                }
            }
            else
            {
                //Throw an error?
            }
        }

        public static void StopExamById(Guid id)
        {
            var ex = ActiveExams.Where(x => x.ExamId.Equals(id));

            if (ex.ToArray().Length != 0)
            {
                foreach (var index in ex.ToList())
                {
                    ActiveExams.Remove(index);
                    Exams.Add(index);
                }
            }
            else
            {
                //Throw an error?
            }
        }

        public static void RemoveExamById(Guid id)
        {
            var ex = Exams.Where(x => x.ExamId.Equals(id));

            if (ex.ToArray().Length != 0)
            {
                foreach (var index in ex.ToList())
                {
                    Exams.Remove(index);
                }
            }
            else
            {
                //Throw an error?
            }
        }

        public static IList<Exam> GetActiveExams()
        {
            return ActiveExams;
        }

        public static IList<Exam> GetAvailableExams()
        {
            return Exams;
        }

        public static Exam GetExamById(Guid id)
        {
            var ex = Exams.Where(x => x.ExamId.Equals(id));

            if (ex.ToArray().Length != 0)
            {
                return ex.First();
            }
            else
            {
                //Throw an error?
            }
            return null;
        }

        public static Exam GetActiveExamById(Guid id)
        {
            var ex = ActiveExams.Where(x => x.ExamId.Equals(id));

            if (ex.ToArray().Length != 0)
            {
                return ex.First();
            }
            else
            {
                //Throw an error?
            }
            return null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataModels.Questions;

namespace WebserviceTest
{
    public class MockData
    {
        public MockData()
        {
        }

        public IList<Answer> GetMockAnswers()
        {
            var ansList = new List<Answer>();
            for (var i = 0; i < 10; i++)
            {
                ansList.Add(new Answer(Guid.NewGuid(), QuestionType.FillInTheBlank, null));
            }
            return ansList;
        }

    }
}

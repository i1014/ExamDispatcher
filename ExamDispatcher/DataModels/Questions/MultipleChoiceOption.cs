using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Questions
{
    [Serializable]
    public class MultipleChoiceOption
    {
        public string Option { get; private set; }
        public bool Correct { get; set; }

        public MultipleChoiceOption()
        {
        }

        public MultipleChoiceOption(string option, bool correct)
        {
            Option = option;
            Correct = correct;
        }
    }
}

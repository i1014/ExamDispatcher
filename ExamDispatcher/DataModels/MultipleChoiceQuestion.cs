
namespace DataModels
{
    public class MultipleChoiceQuestion : Question
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public QuestionType Type { get; private set; }

        public MultipleChoiceQuestion()
        {
            Question = "";
            Answer = "";
            Type = QuestionType.MultipleChoice;
        }

        public MultipleChoiceQuestion(string question, string answer)
        {
            Question = question;
            Answer = answer;
            Type = QuestionType.MultipleChoice;
        }
    }
}

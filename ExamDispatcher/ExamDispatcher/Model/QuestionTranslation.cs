using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Questions;
using ExamDispatcher.ViewModel;
using ExamDispatcher.ViewModel.Questions;
using GalaSoft.MvvmLight;

namespace ExamDispatcher.Model
{
    public static class QuestionTranslation
    {
        public static BaseQuestionViewModel EditViewModelFromEnum(QuestionType type, BaseQuestion question, ViewModelBase parent)
        {
            switch (type)
            {
                case QuestionType.AllThatApply :
                    
                    break;
                case QuestionType.FillInTheBlank :

                    break;
                case QuestionType.Matching :

                    break;
                case QuestionType.MultipleChoice :
                    return new MultipleChoiceViewModel(parent as ExamViewModel, question as MultipleChoiceQuestion);
                case QuestionType.ShortAnswer :
                    return new ShortAnswerViewModel(question as ShortAnswerQuestion, parent);
            }
            return null;
        }
    }
}

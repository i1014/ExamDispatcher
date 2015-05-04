using DataModels.Questions;
using GalaSoft.MvvmLight;

namespace ExamDispatcher.ViewModel.Questions
{
    public abstract class BaseQuestionViewModel : ViewModelBase
    {
        public ViewModelBase ParentViewModel;
        public abstract BaseQuestion GetQuestion();
    }
}

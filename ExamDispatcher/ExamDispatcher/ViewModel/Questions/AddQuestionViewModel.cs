using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataModels.Questions;
using GalaSoft.MvvmLight;

namespace ExamDispatcher.ViewModel.Questions
{
    public class AddQuestionViewModel : ViewModelBase
    {
        #region Properties
        private ExamViewModel Parent;
        #endregion

        #region Commands
        public ICommand ShortAnswerCommand { get; private set; }
        private void ExecuteShortAnswerCommand()
        {
            Parent.CreateNewQuestion(new ShortAnswerViewModel(new ShortAnswerQuestion("", Guid.NewGuid(),""), Parent));
        }

        public ICommand MultipleChoiceCommand { get; private set; }
        private void ExecuteMultipleChoiceCommand()
        {
            Parent.CreateNewQuestion(new MultipleChoiceViewModel(Parent, new MultipleChoiceQuestion("", Guid.NewGuid(), "", new List<MultipleChoiceOption>())));
        }

        public ICommand MatchingCommand { get; private set; }
        private void ExecuteMatchingCommand()
        {

        }
        #endregion

        public AddQuestionViewModel(ExamViewModel parent)
        {
            Parent = parent;

            ShortAnswerCommand = new RelayCommand(() => ExecuteShortAnswerCommand());
            MultipleChoiceCommand = new RelayCommand(() => ExecuteMultipleChoiceCommand());
            MatchingCommand = new RelayCommand(() => ExecuteMatchingCommand());
        }
        
    }
}

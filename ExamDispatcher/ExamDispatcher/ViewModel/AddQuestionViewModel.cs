using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ExamDispatcher.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ExamDispatcher.ViewModel
{
    public class AddQuestionViewModel : ViewModelBase
    {
        #region ViewmodelInitiation
        private BaseQuestionViewModel _currentViewModel;
        public BaseQuestionViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }
        #endregion

        #region ViewModelRegistration
        readonly ShortAnswerViewModel _ShortAnswerViewModel = new ShortAnswerViewModel();
        readonly MultipleChoiceViewModel _MultipleChoiceViewModel = new MultipleChoiceViewModel();
        #endregion

        #region Commands
        public ICommand MultipleChoiceCommand { get; private set; }
        private void ExecuteMultipleChoiceCommand()
        {
            CurrentViewModel = this._MultipleChoiceViewModel;
        }

        public ICommand ShortAnswerCommand { get; private set; }
        private void ExecuteShortAnswerCommand()
        {
            CurrentViewModel = this._ShortAnswerViewModel;
        }

        public ICommand TrueFalseCommand { get; private set; }
        private void ExecuteTrueFalseCommand()
        {

        }

        public ICommand MatchingCommand { get; private set; }
        private void ExecuteMatchingCommand()
        {

        }

        public ICommand AllThatApplyCommand { get; private set; }
        private void ExecuteAllThatApplyCommand()
        {

        }

        public ICommand CreateCommand { get; private set; }
        private void ExecuteCreateCommand()
        {
            var question = CurrentViewModel.GetQuestion();
            DataStore.AddedQuestion = question;
            ExecuteCancelCommand();
        }

        public ICommand CancelCommand { get; private set; }
        private void ExecuteCancelCommand()
        {
            DataStore.WindowRegistration.Content = null;
            DataStore.WindowRegistration.Close();
        }
        #endregion


        public AddQuestionViewModel()
        {
            CurrentViewModel = this._ShortAnswerViewModel;

            MultipleChoiceCommand = new RelayCommand(() => ExecuteMultipleChoiceCommand());
            ShortAnswerCommand = new RelayCommand(() => ExecuteShortAnswerCommand());
            TrueFalseCommand = new RelayCommand(() => ExecuteTrueFalseCommand());
            MatchingCommand = new RelayCommand(() => ExecuteMatchingCommand());
            AllThatApplyCommand = new RelayCommand(() => ExecuteAllThatApplyCommand());

            CreateCommand = new RelayCommand(() => ExecuteCreateCommand());
            CancelCommand = new RelayCommand(() => ExecuteCancelCommand());

            //CreateExamCommand = new RelayCommand(() => ExecuteCreateCommand());
            //HostExamCommand = new RelayCommand(() => ExecuteHostCommand());


            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using DataModels;

namespace ExamDispatcher.ViewModel
{
    public class CreateExamViewModel : ViewModelBase
    {

        private string _ExamName;
        public string ExamName
        {
            get { return _ExamName; }
            set
            {
                if (_ExamName == value)
                    return;
                _ExamName = value;
                RaisePropertyChanged("ExamName");
            }
        }

        private ObservableCollection<BaseQuestion> _Questions;
        public ObservableCollection<BaseQuestion> Questions
        {
            get { return _Questions; }
            set
            {
                if (_Questions == value)
                    return;
                _Questions = value;
                RaisePropertyChanged("Questions");
            }
        }

        private BaseQuestion _SelectedItem;
        public BaseQuestion SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (value == _SelectedItem)
                    return;

                _SelectedItem = value;
                RaisePropertyChanged("SelectedItem");

                // selection changed - do something special
            }
        }

        #region Commands
        
        public ICommand EditCommand { get; private set; }
        private void ExecuteEditCommand()
        {
            
        }

        public ICommand AddCommand { get; private set; }
        private void ExecuteAddCommand()
        {
            var sa = new ShortAnswerQuestion(ExamName, "A");
            _Questions.Add(sa);
        }

        public ICommand RemoveCommand { get; private set; }
        private void ExecuteRemoveCommand()
        {

        }

        public ICommand SaveCommand { get; private set; }
        private void ExecuteSaveCommand()
        {

        }
        #endregion

        public CreateExamViewModel()
        {
            _Questions = new ObservableCollection<BaseQuestion>(new List<BaseQuestion>());

            EditCommand = new RelayCommand(() => ExecuteEditCommand());
            AddCommand = new RelayCommand(() => ExecuteAddCommand());
            RemoveCommand = new RelayCommand(() => ExecuteRemoveCommand());
            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());

        }

    }
}

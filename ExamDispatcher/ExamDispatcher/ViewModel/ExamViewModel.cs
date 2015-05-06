using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using DataModels;
using DataModels.Questions;
using ExamDispatcher.Model;
using ExamDispatcher.ViewModel.Questions;
using ExamDispatcher.Views;
using Microsoft.Win32;
using Utilities;

namespace ExamDispatcher.ViewModel
{
    public class ExamViewModel : ViewModelBase
    {

        #region Properties and Fields

        private int ExamDuration;
        private MainViewModel parentViewModel;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
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

        private Guid _ExamGuid;
        public Guid ExamGuid
        {
            get { return _ExamGuid; }
            set
            {
                if (_ExamGuid == value)
                    return;
                _ExamGuid = value;
                RaisePropertyChanged("ExamGuid");
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
            }
        }
        #endregion

        #region ViewModel Registration

        #endregion

        #region Commands
        public ICommand EditCommand { get; private set; }
        private void ExecuteEditCommand()
        {
            CurrentViewModel = QuestionTranslation.EditViewModelFromEnum(SelectedItem.Type, SelectedItem, this);
        }

        public ICommand AddCommand { get; private set; }
        private void ExecuteAddCommand()
        {
            CurrentViewModel = new AddQuestionViewModel(this);

        }

        public ICommand RemoveCommand { get; private set; }
        private void ExecuteRemoveCommand()
        {
            Questions.Remove(SelectedItem);
        }

        public ICommand SaveCommand { get; private set; }
        private void ExecuteSaveCommand()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = parentViewModel.Path;//Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = ExamName;
            saveFileDialog.DefaultExt = ".bin";

            if (saveFileDialog.ShowDialog() == true)
            {
                var fileName = saveFileDialog.FileName;
                if (ExamGuid.Equals(new Guid("00000000-0000-0000-0000-000000000000")))
                    ExamGuid = Guid.NewGuid();
                var exam = new Exam(ExamName, ExamGuid, Questions.ToList(), ExamDuration);
                var serializer = new ObjectSerialization<Exam>(exam, fileName);
                serializer.Serialize();
            }
        }

        public ICommand EditSettingsCommand { get; private set; }
        private void ExecuteEditSettingsCommand()
        {
            CurrentViewModel = new ExamSettingsViewModel(this, ExamName, ExamDuration, ExamGuid.ToString());
        }
        #endregion


        #region Updates
        public void UpdateQuestion(BaseQuestion baseQuestion)
        {
            var original = from x in Questions
                where x.QuestionGuid.Equals(baseQuestion.QuestionGuid)
                select x;

            if (!original.Any())
            {
                Questions.Add(baseQuestion);
            }
            else
            {
                Questions.Remove(original.First());
                Questions.Add(baseQuestion);
                
            }
        }

        public void UpdateExamSettings(string examName, int length)
        {
            ExamName = examName;
            ExamDuration = length;
        }

        public void CreateNewQuestion(BaseQuestionViewModel viewModel)
        {
            CurrentViewModel = viewModel;
        }
        #endregion

        public ExamViewModel(Exam exam, MainViewModel parent)
        {
            parentViewModel = parent;


            _Questions = new ObservableCollection<BaseQuestion>(new List<BaseQuestion>());

            AddCommand = new RelayCommand(() => ExecuteAddCommand());
            EditCommand = new RelayCommand(() => ExecuteEditCommand());
            RemoveCommand = new RelayCommand(() => ExecuteRemoveCommand());
            EditSettingsCommand = new RelayCommand(() => ExecuteEditSettingsCommand());
            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());

            ExamName = exam.ExamTitle;
            ExamGuid = exam.ExamId;
            ExamDuration = exam.Minutes;
            Questions = new ObservableCollection<BaseQuestion>(exam.QuestionList);
            CurrentViewModel = new ExamSettingsViewModel(this, ExamName, ExamDuration, ExamGuid.ToString());
        }

        public ExamViewModel()
        {
            CurrentViewModel = new SplashViewModel();
            

            _Questions = new ObservableCollection<BaseQuestion>(new List<BaseQuestion>());

            AddCommand = new RelayCommand(() => ExecuteAddCommand());
            EditCommand = new RelayCommand(() => ExecuteEditCommand());
            RemoveCommand = new RelayCommand(() => ExecuteRemoveCommand());
            EditSettingsCommand = new RelayCommand(() => ExecuteEditSettingsCommand());
            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());

        }

    }
}

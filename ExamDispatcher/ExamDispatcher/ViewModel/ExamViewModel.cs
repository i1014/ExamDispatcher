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

        private ViewModelBase parentViewModel;

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
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = ExamName;
            saveFileDialog.DefaultExt = ".bin";

            if (saveFileDialog.ShowDialog() == true)
            {
                var fileName = saveFileDialog.FileName;
                if (ExamGuid.Equals(new Guid("00000000-0000-0000-0000-000000000000")))
                    ExamGuid = Guid.NewGuid();
                var exam = new Exam(ExamName, ExamGuid, Questions.ToList());
                var serializer = new ObjectSerialization<Exam>(exam, fileName);
                serializer.Serialize();
            }
        }

        public ICommand EditSettingsCommand { get; private set; }
        private void ExecuteEditSettingsCommand()
        {
            
        }
        #endregion

        public void UpdateQuestion(BaseQuestion baseQuestion)
        {
            var original = from x in Questions
                where x.QuestionGuid.Equals(baseQuestion.QuestionGuid)
                select x;

            Questions.Remove(original.First());
            Questions.Add(baseQuestion);
        }

        public ExamViewModel(Exam exam, ViewModelBase parent)
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
            Questions = new ObservableCollection<BaseQuestion>(exam.QuestionList);
        }

        public ExamViewModel()
        {
            _Questions = new ObservableCollection<BaseQuestion>(new List<BaseQuestion>());

            AddCommand = new RelayCommand(() => ExecuteAddCommand());
            EditCommand = new RelayCommand(() => ExecuteEditCommand());
            RemoveCommand = new RelayCommand(() => ExecuteRemoveCommand());
            EditSettingsCommand = new RelayCommand(() => ExecuteEditSettingsCommand());
            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());

        }

    }
}

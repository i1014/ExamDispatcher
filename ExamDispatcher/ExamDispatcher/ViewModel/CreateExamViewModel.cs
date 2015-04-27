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
using ExamDispatcher.Views;
using Microsoft.Win32;
using Utilities;

namespace ExamDispatcher.ViewModel
{
    public class CreateExamViewModel : ViewModelBase
    {

        #region Properties and Fields
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
        readonly static AddQuestionViewModel _AddQuestionViewModel = new AddQuestionViewModel();
        #endregion

        #region Commands
        public ICommand EditCommand { get; private set; }
        private void ExecuteEditCommand()
        {
            
        }

        public ICommand AddCommand { get; private set; }
        private void ExecuteAddCommand()
        {
            var w = new Window {Content = new AddQuestionViewModel()};
            w.Height = 525;
            w.Width = 320;
            DataStore.WindowRegistration = w;
            w.ShowDialog();

            var tmp = DataStore.AddedQuestion;
            var error = DataStore.ErrorCode;

            if (error == 0)
            {
                if(tmp != null)
                    Questions.Add(tmp);
            }
            else
            {
                //TODO Alert user with dialog and error code translation.
            }

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
                var exam = new Exam(ExamName, Guid.NewGuid(), Questions.ToList());
                var serializer = new ObjectSerialization<Exam>(exam, fileName);
                serializer.Serialize();
            }
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

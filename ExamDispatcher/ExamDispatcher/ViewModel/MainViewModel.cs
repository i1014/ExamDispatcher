using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using DataModels;
using DataModels.Questions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Utilities;

namespace ExamDispatcher.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties and Fields

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        private ObservableCollection<Exam> _exams;

        public ObservableCollection<Exam> Exams
        {
            get { return _exams; }
            set
            {
                if (_exams == value)
                    return;
                _exams = value;
                RaisePropertyChanged("Exams");
            }
        }

        private Exam _selectedItem;

        public Exam SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value == _selectedItem)
                    return;

                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        #endregion

        #region ViewModelRegistration

        private static readonly ExamViewModel _CreateExamViewModel = new ExamViewModel();
        private static readonly HostExamViewModel _HostExamViewModel = new HostExamViewModel();

        #endregion

        #region Commands

        public ICommand CreateExamCommand { get; private set; }

        private void ExecuteCreateCommand()
        {
            _CreateExamViewModel.ExamGuid = Guid.NewGuid();

            CurrentViewModel = MainViewModel._CreateExamViewModel;
        }

        public ICommand SelectExamCommand { get; private set; }

        private void ExecuteSelectExamCommand()
        {
            var create = new ExamViewModel(SelectedItem, this);
            CurrentViewModel = create;
        }

        #endregion


        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._CreateExamViewModel;
            Exams = new ObservableCollection<Exam>();
            CreateExamCommand = new RelayCommand(() => ExecuteCreateCommand());
            SelectExamCommand = new RelayCommand(() => ExecuteSelectExamCommand());

            var path = GetFolder();
            RefreshExams(path);

        }

        #region Private Methods

        private string GetFolder()
        {
            FolderBrowserDialog folderPicker = new FolderBrowserDialog();
            if (folderPicker.ShowDialog() == DialogResult.OK)
            {

                var path = folderPicker.SelectedPath;

                return path;
            }

            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void RefreshExams(string path)
        {
            var files = System.IO.Directory.GetFiles(path, "*.bin");
            foreach (var file in files)
            {
                var serializer = new ObjectSerialization<Exam>(null, file);
                var exam = serializer.DeSerialize();
                if (exam != null)
                {
                    foreach (var question in exam.QuestionList)
                    {
                        question.Type = EnumTranslation.EnumFromType(question);
                    }
                    Exams.Add(exam);

                }
            }
        }

        #endregion



    }
}
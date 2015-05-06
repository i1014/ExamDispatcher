using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using DataModels;
using DataModels.Questions;
using ExamDispatcher.Model;
using ExamDispatcher.ViewModel.Questions;
using ExamSandbox;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Utilities;
using Webservice;

namespace ExamDispatcher.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables for internal use
        public string Path { get; private set; }
        #endregion  

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

        private static readonly ExamViewModel _examViewModel = new ExamViewModel();
        private static readonly HostExamViewModel _hostExamViewModel = new HostExamViewModel();

        #endregion

        #region Commands

        public ICommand CreateExamCommand { get; private set; }
        private void ExecuteCreateCommand()
        {
            _examViewModel.ExamGuid = Guid.NewGuid();
            CurrentViewModel = new ExamViewModel(new Exam("",Guid.NewGuid(),new List<BaseQuestion>(),0), this);
        }

        public ICommand SelectExamCommand { get; private set; }
        private void ExecuteSelectExamCommand()
        {
            if (SelectedItem == null)
                return;

            var create = new ExamViewModel(SelectedItem, this);
            CurrentViewModel = create;
        }

        public ICommand RefreshCommand { get; private set; }
        private void ExecuteRefreshCommand()
        {
            RefreshExams(Path);
        }

        public ICommand ChangeFolderCommand { get; private set; }
        private void ExecuteChangeFolderCommand()
        {
            Path = GetFolder();
            RefreshExams(Path);
        }

        public ICommand HostExamCommand { get; private set; }
        private void ExecuteHostExamCommand()
        {
            _hostExamViewModel.Exam = SelectedItem;
            CurrentViewModel = _hostExamViewModel;
        }
        #endregion


        public MainViewModel()
        {
            CurrentViewModel = new SplashViewModel();
            Exams = new ObservableCollection<Exam>();
            CreateExamCommand = new RelayCommand(() => ExecuteCreateCommand());
            SelectExamCommand = new RelayCommand(() => ExecuteSelectExamCommand());
            RefreshCommand = new RelayCommand(() => ExecuteRefreshCommand());
            ChangeFolderCommand = new RelayCommand(() => ExecuteChangeFolderCommand());
            HostExamCommand = new RelayCommand(() => ExecuteHostExamCommand());

            if (!this.IsInDesignMode)
            {
                Path = GetFolder();
                RefreshExams(Path);
                
            }


        }

        #region Private Methods

        private string GetFolder()
        {
            var folderPicker = new FolderBrowserDialog();
            folderPicker.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); ;
            if (folderPicker.ShowDialog() == DialogResult.OK)
            {

                var path = folderPicker.SelectedPath;

                return path;
            }

            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void RefreshExams(string path)
        {
            Exams = new ObservableCollection<Exam>();

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
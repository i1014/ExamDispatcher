using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Utilities;

namespace ExamDispatcher.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region ViewmodelInitiation
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
        #endregion

        #region ViewModelRegistration
        readonly static CreateExamViewModel _CreateExamViewModel = new CreateExamViewModel();
        readonly static HostExamViewModel _HostExamViewModel = new HostExamViewModel();
        #endregion

        #region Commands
        public ICommand CreateExamCommand { get; private set; }
        private void ExecuteCreateCommand()
        {
            CurrentViewModel = MainViewModel._CreateExamViewModel;
        }

        public ICommand EditExamCommand { get; private set; }
        private void ExecuteEditExamCommand()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.DefaultExt = ".bin";
            var viewModel = new CreateExamViewModel();

            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;

                var serializer = new ObjectSerialization<Exam>(null, fileName);
                var exam = serializer.DeSerialize();

                viewModel.ExamName = exam.ExamTitle;
                viewModel.Questions = new ObservableCollection<BaseQuestion>(exam.QuestionList);
                viewModel.ExamGuid = exam.ExamId;

                CurrentViewModel = viewModel;

            }

        }

        public ICommand HostExamCommand { get; private set; }
        private void ExecuteHostCommand()
        {
            CurrentViewModel = MainViewModel._HostExamViewModel;
        }
        #endregion


        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._HostExamViewModel;
            CreateExamCommand = new RelayCommand(() => ExecuteCreateCommand());
            HostExamCommand = new RelayCommand(() => ExecuteHostCommand());
            EditExamCommand = new RelayCommand(() => ExecuteEditExamCommand());


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
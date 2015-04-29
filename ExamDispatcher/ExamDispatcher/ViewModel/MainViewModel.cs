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

        private ObservableCollection<Exam> _exams;
        public ObservableCollection<Exam> Exams
        {
            get
            {
                return _exams;
            }
            set
            {
                if (_exams == value)
                    return;
                _exams = value;
                RaisePropertyChanged("Exams");
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
            _CreateExamViewModel.ExamGuid = Guid.NewGuid();

            CurrentViewModel = MainViewModel._CreateExamViewModel;
        }
        #endregion


        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._CreateExamViewModel;
            Exams = new ObservableCollection<Exam>();
            CreateExamCommand = new RelayCommand(() => ExecuteCreateCommand());


        }


    }
}
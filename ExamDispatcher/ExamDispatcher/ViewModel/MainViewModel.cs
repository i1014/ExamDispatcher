using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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

        public ICommand HostExamCommand { get; private set; }
        private void ExecuteHostCommand()
        {
            CurrentViewModel = MainViewModel._HostExamViewModel;
        }
        #endregion


        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._CreateExamViewModel;
            CreateExamCommand = new RelayCommand(() => ExecuteCreateCommand());
            HostExamCommand = new RelayCommand(() => ExecuteHostCommand());


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
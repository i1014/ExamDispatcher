using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using DataModels.Questions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;

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
            //TODO Recreate an exam creation view.
        }
        #endregion


        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._CreateExamViewModel;
            CreateExamCommand = new RelayCommand(() => ExecuteCreateCommand());
            //ConfigurationManager.AppSettings["Path"] = "C:\\";
            var config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetEntryAssembly().Location);
            

            
            var path = ConfigurationManager.AppSettings["Path"];

            if (path != null)
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                var file = dialog.FileName;
                if (result.Equals(CommonFileDialogResult.Ok))
                {
                    config.AppSettings.Settings.Add("Path", file);
                    config.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    //TODO EXIT
                }
            }

            path = ConfigurationManager.AppSettings["Path"];
            
        }


    }
}
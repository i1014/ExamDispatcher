using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ExamDispatcher.ViewModel.Questions
{
    public class ExamSettingsViewModel : ViewModelBase
    {
        #region Properties and Fields

        private ExamViewModel Parent;

        private string _examName;
        public string ExamName
        {
            get
            {
                return _examName;
            }
            set
            {
                if (_examName == value)
                    return;
                _examName = value;
                RaisePropertyChanged("ExamName");
            }
        }

        private string _examGuid;
        public string ExamGuid
        {
            get
            {
                return _examGuid;
            }
            set
            {
                if (_examGuid == value)
                    return;
                _examGuid = value;
                RaisePropertyChanged("ExamGuid");
            }
        }

        public string _length;
        public string Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (_length == value)
                    return;
                _length = value;
                RaisePropertyChanged("Length");
            }
        }
        #endregion

        #region Commands
        public ICommand SaveCommand { get; private set; }
        private void ExecuteSaveCommand()
        {
            int length;
            if (!Int32.TryParse(Length, out length))
                return;

            Parent.UpdateExamSettings(ExamName, length);
        }

        public ICommand UpMinCommand { get; private set; }
        private void ExecuteUpMinCommand()
        {
            int length;
            if (!Int32.TryParse(Length, out length))
                return;
            length++;
            Length = length.ToString();
        }

        public ICommand DownMinCommand { get; private set; }
        private void ExecuteDownMinCommand()
        {
            int length;
            if (!Int32.TryParse(Length, out length))
                return;
            length--;
            Length = length.ToString();
        }
        #endregion

        public ExamSettingsViewModel(ExamViewModel parent, string examName, int minutes, string examGuid)
        {
            ExamName = examName;
            Length = minutes.ToString();
            ExamGuid = examGuid;

            Parent = parent;
            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());
            UpMinCommand = new RelayCommand(() => ExecuteUpMinCommand());
            DownMinCommand = new RelayCommand(() => ExecuteDownMinCommand());
        }


    }
}

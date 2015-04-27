using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataModels.Questions;
using ExamSandbox;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Webservice;

namespace ExamDispatcher.ViewModel
{
    public class HostExamViewModel : ViewModelBase
    {
        #region Properties and Fields
        private Exam _Exam;
        public Exam Exam
        {
            get { return _Exam; }
            set
            {
                if (_Exam == value)
                    return;
                _Exam = value;
                RaisePropertyChanged("Exam");
            }
        }
        #endregion


        #region Commands
        public ICommand StartExamCommand { get; private set; }
        private void ExecuteStartCommand()
        {
            Program.Start();
            Sandbox.AddExamToSandbox(Exam);
            Sandbox.StartExamById(Exam.ExamId);

        }

        public ICommand StopExamCommand { get; private set; }
        private void ExecuteStopCommand()
        {
            Sandbox.StopExamById(Exam.ExamId);
            Sandbox.RemoveExamById(Exam.ExamId);
        }
        #endregion

        public HostExamViewModel()
        {
            StartExamCommand = new RelayCommand(() => ExecuteStartCommand());
            StopExamCommand = new RelayCommand(() => ExecuteStopCommand());
        }


    }
}

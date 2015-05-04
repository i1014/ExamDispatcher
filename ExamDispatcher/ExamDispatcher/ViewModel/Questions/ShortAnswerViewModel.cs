using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataModels;
using DataModels.Questions;
using ExamDispatcher.Model;
using ExamDispatcher.ViewModel.Questions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ExamDispatcher.ViewModel.Questions
{
    public class ShortAnswerViewModel : BaseQuestionViewModel
    {
        #region Bindings
        private string _examQuestion;
        public string ExamQuestion
        {
            get { return _examQuestion; }
            set
            {
                if (_examQuestion == value)
                    return;
                _examQuestion = value;
                RaisePropertyChanged("ExamQuestion");
            }
        }

        private string _examAnswer;
        public string ExamAnswer
        {
            get { return _examAnswer; }
            set
            {
                if (_examAnswer == value)
                    return;
                _examAnswer = value;
                RaisePropertyChanged("ExamAnswer");
            }
        }
        #endregion

        #region Variables
        private Guid _questionGuid;
        public Guid QuestionGuid
        {
            get { return _questionGuid; }
            set
            {
                if (_questionGuid == value)
                    return;
                _questionGuid = value;
                RaisePropertyChanged("QuestionGuid");
            }
        }

        private ExamViewModel _parent;
        #endregion

        #region Commands

        public ICommand SaveCommand { get; private set; }
        private void ExecuteSaveCommand()
        {
            _parent.UpdateQuestion(GetQuestion());
        }

        #endregion

        public ShortAnswerViewModel(ShortAnswerQuestion question, ViewModelBase parent)
        {
            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());

            if (question != null)
            {
                QuestionGuid = question.QuestionGuid;
                ExamQuestion = question.Question;
                ExamAnswer = question.Answer;
            }
            else
            {
                QuestionGuid = Guid.NewGuid();
            }

            _parent = parent as ExamViewModel;
        }

        public override BaseQuestion GetQuestion()
        {
            if (QuestionGuid.Equals(new Guid("00000000-0000-0000-0000-000000000000")))
                QuestionGuid = Guid.NewGuid();

            return new ShortAnswerQuestion(ExamQuestion, QuestionGuid, ExamAnswer);
        }
    }
}

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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ExamDispatcher.ViewModel
{
    public class ShortAnswerViewModel : BaseQuestionViewModel
    {
        #region Bindings
        private string _ExamQuestion;
        public string ExamQuestion
        {
            get { return _ExamQuestion; }
            set
            {
                if (_ExamQuestion == value)
                    return;
                _ExamQuestion = value;
                RaisePropertyChanged("ExamQuestion");
            }
        }

        private Guid _QuestionGuid;
        public Guid QuestionGuid
        {
            get { return _QuestionGuid; }
            set
            {
                if (_QuestionGuid == value)
                    return;
                _QuestionGuid = value;
                RaisePropertyChanged("QuestionGuid");
            }
        }

        private string _ExamAnswer;
        public string ExamAnswer
        {
            get { return _ExamAnswer; }
            set
            {
                if (_ExamAnswer == value)
                    return;
                _ExamAnswer = value;
                RaisePropertyChanged("ExamAnswer");
            }
        }
        #endregion

        public ShortAnswerViewModel()
        {

        }

        public override BaseQuestion GetQuestion()
        {
            return new ShortAnswerQuestion(ExamQuestion, QuestionGuid, ExamAnswer);
        }
    }
}

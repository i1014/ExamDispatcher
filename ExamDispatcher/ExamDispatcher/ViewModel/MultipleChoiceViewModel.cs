using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataModels;
using DataModels.Questions;
using ExamDispatcher.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace ExamDispatcher.ViewModel
{
    public class MultipleChoiceViewModel : BaseQuestionViewModel
    {
        #region Properties and Fields
        private string _Question;
        public string Question
        {
            get { return _Question; }
            set
            {
                if (_Question == value)
                    return;
                _Question = value;
                RaisePropertyChanged("Question");
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

        private string _Answer;
        public string Answer
        {
            get { return _Answer; }
            set
            {
                if (_Answer == value)
                    return;
                _Answer = value;
                RaisePropertyChanged("SuggestedAnswer");
            }
        }

        private string _Option;
        public string Option
        {
            get { return _Option; }
            set
            {
                if (_Option == value)
                    return;
                _Option = value;
                RaisePropertyChanged("Option");
            }
        }

        private ObservableCollection<MultipleChoiceOption> _Options;
        public ObservableCollection<MultipleChoiceOption> Options
        {
            get { return _Options; }
            set
            {
                if (_Options == value)
                    return;
                _Options = value;
                RaisePropertyChanged("Options");
            }
        }

        private MultipleChoiceOption _SelectedItem;
        public MultipleChoiceOption SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (value == _SelectedItem)
                    return;

                _SelectedItem = value;
                RaisePropertyChanged("SelectedItem");

                // selection changed - do something special
            }
        }
        #endregion

        #region Commands
        public ICommand AddOptionCommand { get; private set; }
        private void ExecuteAddOptionCommand()
        {
            if (Option != "")
            {
                Options.Add(new MultipleChoiceOption(Option, false));
            }
        }

        public ICommand RemoveOptionCommand { get; private set; }
        private void ExecuteRemoveOptionCommand()
        {
            var selected = SelectedItem;

            if (selected != null)
            {
                Options.Remove(SelectedItem);

                if (selected.Option.Equals(Answer))
                    Answer = "";
            }
        }

        public ICommand SetAnswerCommand { get; private set; }
        private void ExecuteSetAnswerCommand()
        {
            foreach (var multipleChoiceOption in Options)
            {
                multipleChoiceOption.Correct = false;
            }

            Options[Options.IndexOf(SelectedItem)].Correct = true;
            Answer = SelectedItem.Option;
        }
        #endregion
        
        public MultipleChoiceViewModel()
        {
            _Options = new ObservableCollection<MultipleChoiceOption>();

            AddOptionCommand = new RelayCommand(() => ExecuteAddOptionCommand());
            RemoveOptionCommand = new RelayCommand(() => ExecuteRemoveOptionCommand());
            SetAnswerCommand = new RelayCommand(() => ExecuteSetAnswerCommand());
        }

        public override BaseQuestion GetQuestion()
        {
            if (Answer == "")
                DataStore.ErrorCode = 10;

            if (QuestionGuid.Equals(new Guid("00000000-0000-0000-0000-000000000000")))
                QuestionGuid = Guid.NewGuid();

            var question = new MultipleChoiceQuestion(Question, QuestionGuid, Answer, Options.ToList());

            return question;
        }
    }
}

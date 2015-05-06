using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataModels.Questions;
using GalaSoft.MvvmLight.CommandWpf;

namespace ExamDispatcher.ViewModel.Questions
{
    public class MultipleChoiceViewModel : BaseQuestionViewModel
    {



        private ExamViewModel _parent;

        #region Properties and Fields

        private ObservableCollection<string> _options;
        public ObservableCollection<string> Options
        {
            get { return _options; }
            set
            {
                if (_options == value)
                    return;
                _options = value;
                RaisePropertyChanged("Options");
            }
        }

        private string _option;
        public string Option
        {
            get { return _option; }
            set
            {
                if (_option == value)
                    return;
                _option = value;
                RaisePropertyChanged("Option");
            }
        }

        private string _question;
        public string Question
        {
            get { return _question; }
            set
            {
                if (_question == value)
                    return;
                _question = value;
                RaisePropertyChanged("Question");
            }
        }

        private string _selection;
        public string Selection
        {
            get { return _selection; }
            set
            {
                if (_selection == value)
                    return;
                _selection = value;
                RaisePropertyChanged("Selection");
            }
        }

        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set
            {
                if (_answer == value)
                    return;
                _answer = value;
                RaisePropertyChanged("Answer");
            }
        }

        private string _answerText;
        public string AnswerText
        {
            get { return _answerText; }
            set
            {
                if (_answerText == value)
                    return;
                _answerText = value;
                RaisePropertyChanged("AnswerText");
            }
        }

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
        #endregion


        #region Command
        public ICommand SaveCommand { get; private set; }
        private void ExecuteSaveCommand()
        {
            if (Answer == "")
                return;

            if (!Option.Any())
                return;

            _parent.UpdateQuestion(GetQuestion());
        }

        public ICommand AddOptionCommand { get; private set; }
        private void ExecuteAddOptionCommand()
        {
            if (Option == "")
                return;
            Options.Add(Option);
        }

        public ICommand RemoveOptionCommand { get; private set; }
        private void ExecuteRemoveOptionCommand()
        {
            if (Selection == null)
                return;
            Options.Remove(Selection);
        }

        public ICommand SetAnswerCommand { get; private set; }
        private void ExecuteSetAnswerCommand()
        {
            if (Selection == null)
                return;
            Answer = Selection;
            AnswerText = "Answer : " + Answer;
        }
        #endregion

        public MultipleChoiceViewModel(ExamViewModel parent, MultipleChoiceQuestion quest)
        {
            Question = quest.Question;
            var opts = quest.Options.Select(x => x.Option);
            Options = new ObservableCollection<string>(opts.ToList());
            Answer = quest.SuggestedAnswer;
            AnswerText = "Answer : " + Answer;

            _parent = parent;

            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());
            AddOptionCommand = new RelayCommand(() => ExecuteAddOptionCommand());
            RemoveOptionCommand = new RelayCommand(() => ExecuteRemoveOptionCommand());
            SetAnswerCommand = new RelayCommand(() => ExecuteSetAnswerCommand());
        }

        public MultipleChoiceViewModel(ExamViewModel parent)
        {
            _parent = parent;

            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());
            AddOptionCommand = new RelayCommand(() => ExecuteAddOptionCommand());
            RemoveOptionCommand = new RelayCommand(() => ExecuteRemoveOptionCommand());
            SetAnswerCommand = new RelayCommand(() => ExecuteSetAnswerCommand());
        }

        public override BaseQuestion GetQuestion()
        {
            var options = new List<MultipleChoiceOption>();
            foreach (var option in Options)
            {
                var cor = (option.Equals(Answer));
                var opt = new MultipleChoiceOption(option, cor);
                options.Add(opt);
            }

            var question = new MultipleChoiceQuestion(Question, QuestionGuid, Answer, options);

            return question;
        }
    }
}

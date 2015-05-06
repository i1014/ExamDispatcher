using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamDispatcher.ViewModel.Questions
{
    public class MatchingViewModel : BaseQuestionViewModel
    {
        private ExamViewModel _parent;

        #region Properties and Fields



        #endregion


        #region Command
        public ICommand SaveCommand { get; private set; }
        private void ExecuteSaveCommand()
        {
            _parent.UpdateQuestion(GetQuestion());
        }
        #endregion

        public MatchingViewModel(ExamViewModel parent)
        {
            _parent = parent;

            SaveCommand = new RelayCommand(() => ExecuteSaveCommand());
        }



        public override DataModels.Questions.BaseQuestion GetQuestion()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using GalaSoft.MvvmLight;

namespace ExamDispatcher.ViewModel
{
    public abstract class BaseQuestionViewModel : ViewModelBase
    {
        public abstract BaseQuestion GetQuestion();
    }
}

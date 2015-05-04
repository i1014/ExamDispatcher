using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ExamDispatcher.ViewModel.Questions
{
    public class ExamSettingsViewModel : ViewModelBase
    {
        #region Properties and Fields

        private ViewModelBase Parent;

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



        #endregion



    }
}

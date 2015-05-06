using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataModels;
using DataModels.Questions;
using Webservice;

namespace ExamDispatcher.Model
{
    public static class DataStore
    {
        public static NancyWebservice Webservice { get; set; }

        static DataStore()
        {
            Webservice = new NancyWebservice();
        }

        private static BaseQuestion _addedQuestion { get; set; }
        public static BaseQuestion AddedQuestion
        {
            get
            {
                var temp = _addedQuestion;
                _addedQuestion = null;
                return temp;
            }
            set { _addedQuestion = value; }
        }

        public static Window WindowRegistration { get; set; }

        private static int _errorCode { get; set; }
        public static int ErrorCode
        {
            get
            {
                var temp = _errorCode;
                _errorCode = 0;
                return temp;
            }
            set { _errorCode = value; }
        }


        public static string ErrorCodeTranslation(int code)
        {
            switch (code)
            {
                case 0  :
                    return "An error occured";
                case 10 :
                    return "SuggestedAnswer not entered";
            }
            return null;
        }

    }
}

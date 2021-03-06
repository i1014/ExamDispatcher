﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Questions;

namespace DataModels.Response
{
    public class ExamResponse
    {
        public string ExamTitle { get; private set; }
        public Guid ExamGuid { get; private set; }
        public long TestDuration { get; private set; }
        public List<ShortAnswerQuestion> ShortAnswerQuestions { get; private set; }
        public List<MultipleChoiceQuestion> MultipleChoiceQuetions { get; private set; }


    }
}

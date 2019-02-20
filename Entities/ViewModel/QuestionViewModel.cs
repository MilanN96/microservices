using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModel
{
    public class QuestionViewModel
    {
       
            public long QuestionID { get; set; }
            public string QuestionValue { get; set; }
            public int TypeOfQuestionID { get; set; }
            public List<OfferedAnswerViewModel> OfferedAnswers { get; set; }
       
    }
}

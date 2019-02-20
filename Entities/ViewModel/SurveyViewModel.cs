using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModel
{
    
    public class SurveyViewModel
    {
        public long SurveyID { get; set; }
        public string SurveyName { get; set; }
        public string Description { get; set; }
        public Guid UserID { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}

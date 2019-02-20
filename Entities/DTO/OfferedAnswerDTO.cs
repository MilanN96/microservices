using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservice.DTO
{
    public class OfferedAnswerDTO
    {
        
        public long OfferedAnswerID { get; set; }

        public string Answer { get; set; }

        public long QuestionID { get; set; }

        public QuestionDTO Question { get; set; }
    }
}

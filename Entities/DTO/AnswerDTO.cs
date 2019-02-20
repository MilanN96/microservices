using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservice.DTO
{
    public class AnswerDTO
    {
        
        public long AnswerID { get; set; }

        public string AnswerValue { get; set; }

        public long QuestionID { get; set; }

        public QuestionDTO Question { get; set; }
    }
}

using SurveyMicroservice.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class TypeOfQuestionDTO
    {
       
        public long TypeOfQuestionID { get; set; }
        public string TypeName { get; set; }
        public string Format { get; set; }
        public IEnumerable<QuestionDTO> Questions { get; set; }
    }
}

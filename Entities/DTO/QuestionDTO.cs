using Entities.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservice.DTO
{
    public class QuestionDTO
    {
        public long QuestionID { get; set; }

        public string QuestionValue { get; set; }

        public long SurveyID { get; set; }

        public long TypeOfQuestionID { get; set; }

        public virtual SurveyDTO Survey { get; set; }

        public virtual TypeOfQuestionDTO TypeOfQuestion { get; set; }

        public IEnumerable<OfferedAnswerDTO> OfferedAnswars { get; set; }

        public IEnumerable<AnswerDTO> Answers { get; set; }
    }
}

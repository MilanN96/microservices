using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservice.DTO
{
    public class SurveyDTO
    {
        public long SurveyID { get; set; }

        public string SurveyName { get; set; }

        public string Description { get; set; }

        public Guid UserID { get; set; }

        public bool IsActive { get; set; }

        public string Language { get; set; }

        public DateTime CreationDate { get; set; }

        public IEnumerable<QuestionDTO> Questions { get; set; }
    }
}

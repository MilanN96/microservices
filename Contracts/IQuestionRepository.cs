using Entities.ViewModel;
using SurveyMicroservice.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionDTO>> GetAllQuestionAsync();
        Task CreateQuestionAsync(QuestionViewModel question, long surveyID);
        Task<IEnumerable<QuestionDTO>> GetQuestionBySurveyIdAsync(long surveyID);
        Task<QuestionDTO> GetQuestionByIdAsync(long questionID);
        Task UpdateQuestionAsync(QuestionDTO dbQuestion, QuestionDTO question);
        Task DeleteQuestionAsync(QuestionDTO question);
    }
}

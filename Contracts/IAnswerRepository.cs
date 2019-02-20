using SurveyMicroservice.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<AnswerDTO>> GetAllAnswerAsync();
        Task CreateAnswerAsync(AnswerDTO answer);
        Task<IEnumerable<AnswerDTO>> GetAnswerByQuestionIdAsync(long questionID);
        Task<AnswerDTO> GetAnswerByIdAsync(long answerID);
        Task UpdateAnswerAsync(AnswerDTO dbAnswer, AnswerDTO answer);
        Task DeleteAsnwerAsync(AnswerDTO answer);
    }
}

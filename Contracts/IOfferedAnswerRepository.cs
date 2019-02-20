using Entities.ViewModel;
using SurveyMicroservice.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOfferedAnswerRepository 
    {
        Task<IEnumerable<OfferedAnswerDTO>> GetAllOfferedAnswerAsync();
        Task CreateOfferedAnswerAsync(OfferedAnswerViewModel offeredAnswer, long questionID);
        Task<OfferedAnswerDTO> GetOfferedAnswerByIdAsync(long offeredAnswerID);
        Task<IEnumerable<OfferedAnswerDTO>> GetOfferedAnswerByQuestionIdAsync(long questionID);
        Task UpdateOfferedAnswerAsync(OfferedAnswerDTO dbOfferedAnswer, OfferedAnswerDTO offeredAnswer);
        Task DeleteOfferedAnswerAsync(OfferedAnswerDTO offeredAnswer);
    }
}

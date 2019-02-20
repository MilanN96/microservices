using Entities.ViewModel;
using SurveyMicroservice.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISurveyRepository 
    {
        Task<IEnumerable<SurveyDTO>> GetAllSurveyAsync();
        Task CreateSurveyAsync(SurveyViewModel survey);
        Task<SurveyDTO> GetSurveyByIdAsync(long surveyID);
        Task UpdateSurveyAsync(SurveyDTO dbSurvey, SurveyDTO survey);
        Task DeleteSurveyAsync(SurveyDTO survey);
    }
}

using Entities.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITypeOfQuestionRepository 
    {
        Task<IEnumerable<TypeOfQuestionDTO>> GetAllTypeOfQuestionAsync();
        Task CreateTypeOfQuestionAsync(TypeOfQuestionDTO typeOfQuestion);
        Task<TypeOfQuestionDTO> GetTypeOfQuestionByIdAsync(long typeOfQuestionID);
        Task UpdateTypeOfQuestionAsync(TypeOfQuestionDTO dbTypeOfQuestion, TypeOfQuestionDTO typeOfQuestion);
        Task DeleteTypeOfQuestionAsync(TypeOfQuestionDTO typeOfQuestion);
    }
}

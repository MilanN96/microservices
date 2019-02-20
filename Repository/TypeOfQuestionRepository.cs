using Contracts;
using Entities.DTO;
using Repository.HelpperMethod;
using SurveyMicroservice.Mapper;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TypeOfQuestionRepository : RepositoryBase<TypeOfQuestion>, ITypeOfQuestionRepository
    {
        public TypeOfQuestionRepository(SurveyContext surveyContext)
            :base(surveyContext)
        {
        }

        public async Task CreateTypeOfQuestionAsync(TypeOfQuestionDTO typeOfQuestion)
        {
            var typeOFQuestionMap = Mapping.Mapper.Map<TypeOfQuestionDTO, TypeOfQuestion>(typeOfQuestion);
            Create(typeOFQuestionMap);
            await SaveAsync();
            typeOfQuestion.TypeOfQuestionID = typeOFQuestionMap.TypeOfQuestionID;
        }

        public async Task DeleteTypeOfQuestionAsync(TypeOfQuestionDTO typeOfQuestion)
        {
            Delete(Mapping.Mapper.Map<TypeOfQuestionDTO, TypeOfQuestion>(typeOfQuestion));
            await SaveAsync();
        }

        public async Task<IEnumerable<TypeOfQuestionDTO>> GetAllTypeOfQuestionAsync()
        {
            var types = await FindAllAsync();
            return Mapping.Mapper.Map<IEnumerable<TypeOfQuestion>, IEnumerable<TypeOfQuestionDTO>>(types);
        }

        public async Task<TypeOfQuestionDTO> GetTypeOfQuestionByIdAsync(long typeOfQuestionID)
        {
            var type = await FindByConditionAync(t => t.TypeOfQuestionID.Equals(typeOfQuestionID));
            return Mapping.Mapper.Map<TypeOfQuestion, TypeOfQuestionDTO>(type.DefaultIfEmpty(new TypeOfQuestion())
                    .FirstOrDefault());
        }

        public async Task UpdateTypeOfQuestionAsync(TypeOfQuestionDTO dbTypeOfQuestion, TypeOfQuestionDTO typeOfQuestion)
        {
            dbTypeOfQuestion.TypeOfQuestionMap(typeOfQuestion);
            Update(Mapping.Mapper.Map<TypeOfQuestionDTO, TypeOfQuestion>(dbTypeOfQuestion));
            await SaveAsync();
        }
    }
}

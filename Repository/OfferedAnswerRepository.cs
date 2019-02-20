using Contracts;
using Entities.ViewModel;
using Repository.HelpperMethod;
using SurveyMicroservice.DTO;
using SurveyMicroservice.Mapper;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OfferedAnswerRepository : RepositoryBase<OfferedAnswer>, IOfferedAnswerRepository
    {
        public OfferedAnswerRepository(SurveyContext surveyContext)
           : base(surveyContext)
        {
        }

        public async Task CreateOfferedAnswerAsync(OfferedAnswerViewModel offeredAnswer, long questionID)
        {
            var offeredAnswerMap = new OfferedAnswer()
            {
                Answer = offeredAnswer.Answer,
                QuestionID = questionID
            };
            Create(offeredAnswerMap);
            await SaveAsync();
            offeredAnswer.OfferedAnswerID = offeredAnswerMap.OfferedAnswerID;
        }

        public async Task DeleteOfferedAnswerAsync(OfferedAnswerDTO offeredAnswer)
        {
            Delete(Mapping.Mapper.Map<OfferedAnswerDTO, OfferedAnswer>(offeredAnswer));
            await SaveAsync();
        }

        public async Task<IEnumerable<OfferedAnswerDTO>> GetAllOfferedAnswerAsync()
        {
            var offeredAnswers = await FindAllAsync();
            return Mapping.Mapper.Map<IEnumerable<OfferedAnswer>, IEnumerable<OfferedAnswerDTO>>(offeredAnswers);
        }

        public async Task<IEnumerable<OfferedAnswerDTO>> GetOfferedAnswerByQuestionIdAsync(long questionID)
        {
            var offeredAnswers = await FindByConditionAync(o => o.QuestionID.Equals(questionID));
            return Mapping.Mapper.Map<IEnumerable<OfferedAnswer>, IEnumerable<OfferedAnswerDTO>>(offeredAnswers);
        }

        public async Task<OfferedAnswerDTO> GetOfferedAnswerByIdAsync(long offeredAnswerID)
        {
            var offeredAnswer = await FindByConditionAync(o => o.OfferedAnswerID.Equals(offeredAnswerID));
            return Mapping.Mapper.Map<OfferedAnswer, OfferedAnswerDTO>(offeredAnswer.DefaultIfEmpty(new OfferedAnswer())
                    .FirstOrDefault());
        }

        public  async Task UpdateOfferedAnswerAsync(OfferedAnswerDTO dbOfferedAnswer, OfferedAnswerDTO offeredAnswer)
        {
            dbOfferedAnswer.OfferedAnswerMap(offeredAnswer);
            Update(Mapping.Mapper.Map<OfferedAnswerDTO, OfferedAnswer>(dbOfferedAnswer));
            await SaveAsync();
        }
    }
}

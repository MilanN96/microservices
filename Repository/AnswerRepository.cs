using Contracts;
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
    public class AnswerRepository: RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(SurveyContext surveyContext)
            : base(surveyContext)
        {
        }

        public async Task CreateAnswerAsync(AnswerDTO answer)
        {
            var answerMap = Mapping.Mapper.Map<AnswerDTO, Answer>(answer);
            Create(answerMap);
            await SaveAsync();
            answer.AnswerID = answerMap.AnswerID;
        }

        public async Task DeleteAsnwerAsync(AnswerDTO answer)
        {
            Delete(Mapping.Mapper.Map<AnswerDTO, Answer>(answer));
            await SaveAsync();
        }

        public async Task<IEnumerable<AnswerDTO>> GetAllAnswerAsync()
        {
            var answers = await FindAllAsync();
            return Mapping.Mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(answers);
        }

        public async Task<AnswerDTO> GetAnswerByIdAsync(long answerID)
        {
            var answer = await FindByConditionAync(a => a.AnswerID.Equals(answerID));
            return Mapping.Mapper.Map<Answer, AnswerDTO>(answer.DefaultIfEmpty(new Answer())
                    .FirstOrDefault());
        }

        public async Task<IEnumerable<AnswerDTO>> GetAnswerByQuestionIdAsync(long questionID)
        {
            var answers = await FindByConditionAync(a => a.QuestionID.Equals(questionID));
            return Mapping.Mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(answers);
        }

        public async Task UpdateAnswerAsync(AnswerDTO dbAnswer, AnswerDTO answer)
        {
            dbAnswer.AnswerMap(answer);
            Update(Mapping.Mapper.Map<AnswerDTO, Answer>(dbAnswer));
            await SaveAsync();
        }
    }
}

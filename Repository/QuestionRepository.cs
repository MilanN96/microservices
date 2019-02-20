using Contracts;
using Entities.ViewModel;
using Microsoft.EntityFrameworkCore;
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
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(SurveyContext surveyContext)
            : base(surveyContext)
        {
        }

        public async Task CreateQuestionAsync(QuestionViewModel question, long surveyID)
        {
            var questionMap = new Question()
            {
                QuestionValue = question.QuestionValue,
                SurveyID = surveyID,
                TypeOfQuestionID = question.TypeOfQuestionID
            };
            Create(questionMap);
            await SaveAsync();
            question.QuestionID = questionMap.QuestionID;
        }

        public async Task DeleteQuestionAsync(QuestionDTO question)
        {
            Delete(Mapping.Mapper.Map<QuestionDTO, Question>(question));
            await SaveAsync();
        }

        public async Task<IEnumerable<QuestionDTO>> GetAllQuestionAsync()
        {
            var questions = await FindAllAsync();
            return Mapping.Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(questions);
        }

        public async Task<QuestionDTO> GetQuestionByIdAsync(long questionID)
        {
            var question = await FindByConditionAync(q => q.QuestionID.Equals(questionID));
            return Mapping.Mapper.Map<Question, QuestionDTO>(question.DefaultIfEmpty(new Question())
                    .FirstOrDefault());
        }

        public async Task<IEnumerable<QuestionDTO>> GetQuestionBySurveyIdAsync(long surveyID)
        {
            var questions = await FindByConditionAync(q => q.Survey.SurveyID.Equals(surveyID));
            return Mapping.Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(questions);
        }

        public async Task UpdateQuestionAsync(QuestionDTO dbQuestion, QuestionDTO question)
        {
            dbQuestion.QuestionMap(question);
            Update(Mapping.Mapper.Map<QuestionDTO, Question>(dbQuestion));
            await SaveAsync();
        }
    }
}


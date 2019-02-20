using AutoMapper;
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
    public class SurveyRepository: RepositoryBase<Survey>,ISurveyRepository
    {
        private readonly SurveyContext _context;
        public SurveyRepository(SurveyContext surveyContext)
            :base(surveyContext)
        {
            _context = surveyContext;
        }

        public async Task CreateSurveyAsync(SurveyViewModel survey)
        {
            var surveyMap = new Survey()
            {
                UserID = survey.UserID,
                SurveyName = survey.SurveyName,
                Description = survey.Description,
                IsActive = survey.IsActive,
                CreationDate = survey.CreationDate,
                Language = survey.Language

            };
            Create(surveyMap);
            await SaveAsync();
            survey.SurveyID = surveyMap.SurveyID;
        }

        public async Task DeleteSurveyAsync(SurveyDTO survey)
        {
            Delete(new Survey()
            {
                UserID = survey.UserID,
                SurveyName = survey.SurveyName,
                Description = survey.Description,
                IsActive = survey.IsActive,
                CreationDate = survey.CreationDate,
                Language = survey.Language

            });
            await SaveAsync();
        }

        public async Task<IEnumerable<SurveyDTO>> GetAllSurveyAsync()
        {
            var surveys = _context.Surveys.Include(s => s.Questions).ThenInclude(q => q.OfferedAnswars).ToList();
            return Mapping.Mapper.Map <IEnumerable<Survey>,IEnumerable<SurveyDTO>> (surveys);
        }

        public async Task<SurveyDTO> GetSurveyByIdAsync(long surveyID)
        {
            var survey = _context.Surveys.Where(s => s.SurveyID.Equals(surveyID)).Include(s => s.Questions).ThenInclude(q => q.OfferedAnswars).ToList();
            return Mapping.Mapper.Map<Survey,SurveyDTO>(survey.DefaultIfEmpty(new Survey())
                    .FirstOrDefault());
        }

        public async Task UpdateSurveyAsync(SurveyDTO dbSurvey, SurveyDTO survey)
        {
            dbSurvey.SurveyMap(survey);
            Update(Mapping.Mapper.Map<SurveyDTO,Survey>(dbSurvey));
            await SaveAsync();
        }
    }
}

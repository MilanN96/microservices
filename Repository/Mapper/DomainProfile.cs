using AutoMapper;
using Entities.DTO;
using Entities.ViewModel;
using SurveyMicroservice.DTO;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyMicroservice.Mapper
{
    
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Survey, SurveyViewModel>();
            CreateMap<SurveyViewModel, Survey>();
            CreateMap<QuestionDTO, Question>();
            CreateMap<Question, QuestionDTO>();
            CreateMap<AnswerDTO, Answer>();
            CreateMap<Answer, AnswerDTO>();
            CreateMap<OfferedAnswerDTO, OfferedAnswer>();
            CreateMap<OfferedAnswer, OfferedAnswerDTO>();
            CreateMap<TypeOfQuestionDTO, TypeOfQuestion>();
            CreateMap<TypeOfQuestion, TypeOfQuestionDTO>();
        }
    }
}

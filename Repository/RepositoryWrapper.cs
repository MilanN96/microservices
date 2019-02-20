using Contracts;
using SurveyMicroservices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SurveyContext _surveyContext;
        private ISurveyRepository _survey;
        private IQuestionRepository _question;
        private ITypeOfQuestionRepository _typeOfQuestion;
        private IAnswerRepository _answer;
        private IOfferedAnswerRepository _offeredAnswer;

        public ISurveyRepository Survey
        {
            get
            {
                if (_survey == null)
                {
                    _survey = new SurveyRepository(_surveyContext);
                }

                return _survey;
            }
        }

        public IQuestionRepository Question
        {
            get
            {
                if (_question == null)
                {
                    _question = new QuestionRepository(_surveyContext);
                }

                return _question;
            }
        }

        public ITypeOfQuestionRepository TypeOfQuestion
        {
            get
            {
                if (_typeOfQuestion == null)
                {
                    _typeOfQuestion = new TypeOfQuestionRepository(_surveyContext);
                }

                return _typeOfQuestion;
            }
        }

        public IAnswerRepository Answer
        {
            get
            {
                if (_answer == null)
                {
                    _answer = new AnswerRepository(_surveyContext);
                }

                return _answer;
            }
        }

        public IOfferedAnswerRepository OfferedAnswer
        {
            get
            {
                if (_offeredAnswer == null)
                {
                    _offeredAnswer = new OfferedAnswerRepository(_surveyContext);
                }

                return _offeredAnswer;
            }
        }


        public RepositoryWrapper(SurveyContext surveyContext)
        {
            _surveyContext = surveyContext;
        }
    }
}

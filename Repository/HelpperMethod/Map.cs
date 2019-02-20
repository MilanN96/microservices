using Entities.DTO;
using SurveyMicroservice.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.HelpperMethod
{
    public static class Map
    {
        public static void SurveyMap(this SurveyDTO dbSurvey, SurveyDTO survey)
        {
            dbSurvey.UserID = survey.UserID;
            dbSurvey.IsActive = survey.IsActive;
            dbSurvey.Language = survey.Language;
            dbSurvey.Questions = survey.Questions;
        }

        public static void QuestionMap(this QuestionDTO dbQuestion, QuestionDTO question)
        {
            dbQuestion.QuestionValue = question.QuestionValue;
            dbQuestion.SurveyID = question.SurveyID;
            dbQuestion.TypeOfQuestionID = question.TypeOfQuestionID;
        }

        public static void OfferedAnswerMap(this OfferedAnswerDTO dbOfferedAnswer, OfferedAnswerDTO offeredAnswer)
        {
            dbOfferedAnswer.Answer = offeredAnswer.Answer;
            dbOfferedAnswer.QuestionID = offeredAnswer.QuestionID;
        }

        public static void AnswerMap(this AnswerDTO dbAnswer, AnswerDTO answer)
        {
            dbAnswer.AnswerValue = answer.AnswerValue;
            dbAnswer.QuestionID = answer.QuestionID;
        }

        public static void TypeOfQuestionMap(this TypeOfQuestionDTO dbTypeOfquestion, TypeOfQuestionDTO typeOfquestion)
        {
            dbTypeOfquestion.TypeName = typeOfquestion.TypeName;
            dbTypeOfquestion.Format = typeOfquestion.Format;
        }
    }
}

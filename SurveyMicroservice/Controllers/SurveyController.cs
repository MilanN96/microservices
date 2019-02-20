using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.ViewModel;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyMicroservice.DTO;

namespace SurveyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SurveyController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        [HttpGet("{SurveyID}", Name = "SurveyById")]
        public async Task<IActionResult> GetSurveyById(long SurveyID)
        {
            try
            {
                var survey = await _repositoryWrapper.Survey.GetSurveyByIdAsync(SurveyID);
                if (survey.SurveyID.Equals(null))
                {
                    return NotFound();
                }
                else
                {
                    await Log.Post("Return Survey by ID", "200", DateTime.Now.ToString("h:mm:ss tt"));
                    return Ok(survey);
                }
            }
            catch (Exception ex)
            {
                await Log.Post(ex.Message, "500", DateTime.Now.ToString("h:mm:ss tt"));
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody]SurveyViewModel survey)
        {
            try
            {
                if (survey == null)
                {
                    return BadRequest("survey object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repositoryWrapper.Survey.CreateSurveyAsync(survey);

                foreach (var q in survey.Questions)
                {
                    await _repositoryWrapper.Question.CreateQuestionAsync(q, survey.SurveyID);
                    foreach (var o in q.OfferedAnswers)
                    {
                        await _repositoryWrapper.OfferedAnswer.CreateOfferedAnswerAsync(o, q.QuestionID);
                    }
                    
                }
                await Log.Post("Created survey", "201", DateTime.Now.ToString("h:mm:ss tt"));
                return CreatedAtRoute("SurveyById", new { SurveyID = survey.SurveyID }, survey);
            }
            catch(Exception ex)
            {
                await Log.Post(ex.Message, "500", DateTime.Now.ToString("h:mm:ss tt"));
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{surveyID}")]
        public async Task<IActionResult> DeleteSurvey(long surveyID)
        {
            try
            {
                var survey = await _repositoryWrapper.Survey.GetSurveyByIdAsync(surveyID);

                if (survey.SurveyID.Equals(null))
                {
                    return NotFound();
                }

                await _repositoryWrapper.Survey.DeleteSurveyAsync(survey);
                await Log.Post("Deleted survey by id", "204", DateTime.Now.ToString("h:mm:ss tt"));
                return NoContent();
            }
            catch (Exception ex)
            {
                await Log.Post(ex.Message, "500", DateTime.Now.ToString("h:mm:ss tt"));
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
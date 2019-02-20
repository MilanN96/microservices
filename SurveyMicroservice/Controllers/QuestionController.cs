using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyMicroservice.DTO;

namespace SurveyMicroservice.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        
        public QuestionController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var questions = await _repositoryWrapper.Question.GetAllQuestionAsync();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{questionID}", Name = "QuestionById")]
        public async Task<IActionResult> GetQuestionById(long questionID)
        {
            try
            {
                var question = await _repositoryWrapper.Question.GetQuestionByIdAsync(questionID);

                if (question.QuestionID.Equals(null))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(question);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody]QuestionDTO question)
        {
            try
            {
                if(question == null)
                {
                    return BadRequest("Question object is null");
                }

                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repositoryWrapper.Question.CreateQuestionAsync(question);
                return CreatedAtRoute("QuestionById", new { questionID = question.QuestionID }, question);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{QuestionID}")]
        public async Task<IActionResult> DeleteQuestion(long QuestionID)
        {
            try
            {
                var question = await _repositoryWrapper.Question.GetQuestionByIdAsync(QuestionID);

                if (question.QuestionID.Equals(null))
                {
                    return NotFound();
                }

                await _repositoryWrapper.Question.DeleteQuestionAsync(question);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{questionID}")]
        public async Task<IActionResult> UpdateQuestion(long questionID, [FromBody]QuestionDTO question)
        {
            try
            {
                if (question == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbQuestion = await _repositoryWrapper.Question.GetQuestionByIdAsync(questionID);
                if (dbQuestion.QuestionID.Equals(null))
                {
                    return NotFound();
                }

                await _repositoryWrapper.Question.UpdateQuestionAsync(dbQuestion, question);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }*/
}
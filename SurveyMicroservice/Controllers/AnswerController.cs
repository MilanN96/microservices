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
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AnswerController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var answers = await _repositoryWrapper.Answer.GetAllAnswerAsync();
                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{answerID}", Name = "AnswerById")]
        public async Task<IActionResult> GetAnswerById(long answerID)
        {
            try
            {
                var answer = await _repositoryWrapper.Answer.GetAnswerByIdAsync(answerID);

                if (answer.AnswerID.Equals(null))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(answer);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody]AnswerDTO answer)
        {
            try
            {
                if (answer == null)
                {
                    return BadRequest("Question object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repositoryWrapper.Answer.CreateAnswerAsync(answer);
                return CreatedAtRoute("AnswerById", new { answerID = answer.AnswerID }, answer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{answerID}")]
        public async Task<IActionResult> DeleteAnswer(long answerID)
        {
            try
            {
                var answer = await _repositoryWrapper.Answer.GetAnswerByIdAsync(answerID);

                if (answer.AnswerID.Equals(null))
                {
                    return NotFound();
                }

                await _repositoryWrapper.Answer.DeleteAsnwerAsync(answer);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{offeredAnswerID}")]
        public async Task<IActionResult> UpdateAnswer(long answerID, [FromBody]AnswerDTO answer)
        {
            try
            {
                if (answer == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbAnswer = await _repositoryWrapper.Answer.GetAnswerByIdAsync(answerID);
                if (dbAnswer.AnswerID.Equals(null))
                {
                    return NotFound();
                }

                await _repositoryWrapper.Answer.UpdateAnswerAsync(dbAnswer, answer);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
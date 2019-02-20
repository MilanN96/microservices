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
    public class OfferedAnswerController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OfferedAnswerController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var offeredAnswers = await _repositoryWrapper.OfferedAnswer.GetAllOfferedAnswerAsync();
                return Ok(offeredAnswers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{offeredAnswerID}", Name = "OfferedAnswerById")]
        public async Task<IActionResult> GetOfferedAnswerById(long offeredAnswerID)
        {
            try
            {
                var offeredAnswer = await _repositoryWrapper.OfferedAnswer.GetOfferedAnswerByIdAsync(offeredAnswerID);

                if (offeredAnswer.OfferedAnswerID.Equals(null))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(offeredAnswer);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferedAnswer([FromBody]OfferedAnswerDTO offeredAnswer)
        {
            try
            {
                if (offeredAnswer == null)
                {
                    return BadRequest("Question object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repositoryWrapper.OfferedAnswer.CreateOfferedAnswerAsync(offeredAnswer);
                return CreatedAtRoute("OfferedAnswerById", new { offeredAnswerID = offeredAnswer.OfferedAnswerID }, offeredAnswer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{offeredAnswerID}")]
        public async Task<IActionResult> DeleteOfferedAnswer(long offeredAnswerID)
        {
            try
            {
                var offeredAnswer = await _repositoryWrapper.OfferedAnswer.GetOfferedAnswerByIdAsync(offeredAnswerID);

                if (offeredAnswer.OfferedAnswerID.Equals(null))
                {
                    return NotFound();
                }

                await _repositoryWrapper.OfferedAnswer.DeleteOfferedAnswerAsync(offeredAnswer);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{offeredAnswerID}")]
        public async Task<IActionResult> UpdateOfferedAnswer(long offeredAnswerID, [FromBody]OfferedAnswerDTO offeredAnswer)
        {
            try
            {
                if (offeredAnswer == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbOfferedAnswer = await _repositoryWrapper.OfferedAnswer.GetOfferedAnswerByIdAsync(offeredAnswerID);
                if (dbOfferedAnswer.OfferedAnswerID.Equals(null))
                {
                    return NotFound();
                }

                await _repositoryWrapper.OfferedAnswer.UpdateOfferedAnswerAsync(dbOfferedAnswer, offeredAnswer);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }*/
}

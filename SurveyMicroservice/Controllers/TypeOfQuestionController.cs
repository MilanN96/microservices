using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SurveyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfQuestionController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TypeOfQuestionController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypeOFQuestion()
        {
            try
            {
                var typesOfQuestions = await _repositoryWrapper.TypeOfQuestion.GetAllTypeOfQuestionAsync();
                return Ok(typesOfQuestions);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
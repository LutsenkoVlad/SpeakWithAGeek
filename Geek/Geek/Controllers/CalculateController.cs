using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geek.Infrastructure.Repository;
using Geek.Infrastructure.Service;
using Geek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Geek.Controllers
{
    [Route("api/[controller]")]
    public class CalculateController : Controller
    {
        private readonly ICalcResultRepository _calcResRepo;
        private readonly ICalculateService _calcService;
        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ICalcResultRepository repository, ICalculateService calcService, ILogger<CalculateController> logger)
        {
            _calcResRepo = repository;
            _calcService = calcService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("addition")]
        public async Task<IActionResult> AdditionPost(double a, double b)
        {
            _logger.LogTrace($"[AdditionalPost] first number: {a}, second number: {b}");

            CalcResult calcRes = null;
            try
            {
                calcRes = new CalcResult(_calcService.Add(a, b));
                _calcResRepo.Add(calcRes);
                await _calcResRepo.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"[SubtractionPost] error: {ex.Message}, stack: {ex.StackTrace}, innerException: {ex.InnerException?.Message}");
            }

            _logger.LogTrace($"[AdditionalPost] result: {calcRes?.Result}, Id: {calcRes?.Id}");

            return Ok(calcRes.Id);
        }

        [HttpPost]
        [Route("subtraction")]
        public async Task<IActionResult> SubtractionPost(double a, double b)
        {
            _logger.LogTrace($"[SubtractionPost] first number: {a}, second number: {b}");

            CalcResult calcRes = null;
            try
            {
                calcRes = new CalcResult(_calcService.Sub(a, b));
                _calcResRepo.Add(calcRes);
                await _calcResRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SubtractionPost] error: {ex.Message}, stack: {ex.StackTrace}, innerException: {ex.InnerException?.Message}");
            }

            _logger.LogTrace($"[SubtractionPost] result: {calcRes?.Result}, Id: {calcRes?.Id}");

            return Ok(calcRes.Id);
        }

        [HttpPost]
        [Route("multiplication")]
        public async Task<IActionResult> MultiplicationPost(double a, double b)
        {
            _logger.LogTrace($"[MultiplicationPost] first number: {a}, second number: {b}");

            CalcResult calcRes = null;
            try
            {
                calcRes = new CalcResult(_calcService.Mul(a, b));
                _calcResRepo.Add(calcRes);
                await _calcResRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SubtractionPost] error: {ex.Message}, stack: {ex.StackTrace}, innerException: {ex.InnerException?.Message}");
            }

            _logger.LogTrace($"[MultiplicationPost] result: {calcRes?.Result}, Id: {calcRes?.Id}");

            return Ok(calcRes.Id);
        }

        [HttpPost]
        [Route("division")]
        public async Task<IActionResult> DivisionPost(double a, double b)
        {
            _logger.LogTrace($"[DivisionPost] first number: {a}, second number: {b}");

            CalcResult calcRes = null;
            try
            {
                calcRes = new CalcResult(_calcService.Div(a, b));
                _calcResRepo.Add(calcRes);
                await _calcResRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SubtractionPost] error: {ex.Message}, stack: {ex.StackTrace}, innerException: {ex.InnerException?.Message}");
            }

            _logger.LogTrace($"[DivisionPost] result: {calcRes?.Result}, Id: {calcRes?.Id}");

            return Ok(calcRes.Id);
        }

        [HttpPost]
        [Route("exponentiation")]
        public async Task<IActionResult> ExponentiationPost(double number)
        {
            _logger.LogTrace($"[ExponentiationPost] number: {number}");

            CalcResult calcRes = null;
            try
            {
                calcRes = new CalcResult(_calcService.Exp(number));
                _calcResRepo.Add(calcRes);
                await _calcResRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[SubtractionPost] error: {ex.Message}, stack: {ex.StackTrace}, innerException: {ex.InnerException?.Message}");
            }

            _logger.LogTrace($"[ExponentiationPost] result: {calcRes?.Result}, Id: {calcRes?.Id}");

            return Ok(calcRes.Id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

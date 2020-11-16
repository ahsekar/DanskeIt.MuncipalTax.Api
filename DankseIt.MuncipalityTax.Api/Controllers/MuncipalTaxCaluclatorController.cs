using System.Threading.Tasks;
using DankseIt.MuncipalityTax.Api.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DankseIt.MuncipalityTax.Api.Controllers
{
    [Route("api/tax")]
    [ApiController]
    public class MuncipalTaxCaluclatorController : ControllerBase
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly ILogger<MuncipalTaxCaluclatorController> _logger;

        public MuncipalTaxCaluclatorController(ITaxCalculator taxCalculator, ILogger<MuncipalTaxCaluclatorController> logger)
        {
            _taxCalculator = taxCalculator;
            _logger = logger;
        }

        // GET api/<MuncipalTaxCaluclatorController>/5
        [HttpGet("getTax")]
        public async Task<IActionResult> Get(string muncipalityName, string date)
        {
            _logger.LogInformation($"Get End point Called for {muncipalityName} | date:{date}");
            var result = await _taxCalculator.CalculateTax(muncipalityName, date);
            if (result == 0.0) return BadRequest("Not Able to match details");
            else return Ok(result);
        }

        // POST api/<MuncipalTaxCaluclatorController>
        [HttpPost("createTax")]
        public async Task<IActionResult> Post([FromBody] dynamic value)
        {
            _logger.LogInformation("Post End point Called to create tax");
            var result = await _taxCalculator.CreateTax(value.ToString());
            if (result) return Ok("Success");
            else return BadRequest("Failed");
        }
    }
}

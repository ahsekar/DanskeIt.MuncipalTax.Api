using System.Threading.Tasks;
using DankseIt.MuncipalityTax.Api.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DankseIt.MuncipalityTax.Api.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("{id}")]
        public string Get(string muncipalityName, string date)
        {
            return "value";
        }

        // POST api/<MuncipalTaxCaluclatorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            _logger.LogInformation("Post End point Called to create tax");
            var result = await _taxCalculator.CreateTax(value);
            if (result) return Ok("Success");
            else return BadRequest("Failed");
        }
    }
}

using DankseIt.MuncipalityTax.Api.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DankseIt.MuncipalityTax.Api.Business
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly ILogger<TaxCalculator> _logger;
        private readonly IMemoryCache _memoryCache;

        public TaxCalculator(ILogger<TaxCalculator> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// CalculateTax
        /// </summary>
        /// <param name="muncipality"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<double> CalculateTax(string muncipality, DateTime dateTime)
        {
            double taxrate = 0.0;
            _logger.LogInformation($"Calculating tax for {muncipality} on {dateTime}");
            return taxrate;
        }

        /// <summary>
        /// CreateTax
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public async Task<bool> CreateTax(string values)
        {
            try
            {
                var model = JsonSerializer.Deserialize<MuncipalTax>(values);
                _logger.LogInformation($"Create tax for muncipality:{model.MuncipalityName}");
                _memoryCache.Set(model.MuncipalityName, values);//Can be replaced with DB
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in creating muncipality:{ex.Message}");
            }
            return false;
        }
    }
}

using DankseIt.MuncipalityTax.Api.Models;
using DankseIt.MuncipalityTax.Api.StrategyPattern;
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
        private readonly ITaxCalculationStrategy _taxCalculationStrategy;

        public TaxCalculator(ILogger<TaxCalculator> logger, IMemoryCache memoryCache, ITaxCalculationStrategy taxCalculationStrategy)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _taxCalculationStrategy = taxCalculationStrategy;
        }

        /// <summary>
        /// CalculateTax
        /// </summary>
        /// <param name="muncipality"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<double> CalculateTax(string muncipality, string date)
        {
            double taxrate = 0.0;
            try
            {
                var taxDetails = JsonSerializer.Deserialize<MuncipalTax>(_memoryCache.Get(muncipality)?.ToString());//Can be replaced with database
                if (!string.IsNullOrWhiteSpace(muncipality) && taxDetails != null && !string.IsNullOrWhiteSpace(date))
                {
                    _logger.LogInformation($"Calculating tax for {muncipality} on {date}");
                    DateTime inputDate = Convert.ToDateTime(date);

                    _taxCalculationStrategy.SetSortStrategy(new DailyTaxCalc());
                    taxrate = _taxCalculationStrategy.ProcessTax(inputDate, taxDetails);
                    if (taxrate == 0.0)
                    {
                        _taxCalculationStrategy.SetSortStrategy(new WeeklyTaxCalc());
                        taxrate = _taxCalculationStrategy.ProcessTax(inputDate, taxDetails);
                    }
                    if (taxrate == 0.0)
                    {
                        _taxCalculationStrategy.SetSortStrategy(new MonthlyTaxCalc());
                        taxrate = _taxCalculationStrategy.ProcessTax(inputDate, taxDetails);
                    }
                    if (taxrate == 0.0)
                    {
                        _taxCalculationStrategy.SetSortStrategy(new YearlyTaxCalc());
                        taxrate = _taxCalculationStrategy.ProcessTax(inputDate, taxDetails);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception in Fetching tax for muncipality:{muncipality} | date:{date}");
            }
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
                _memoryCache.Set(model.MuncipalityName, values);//Can be replaced with DataBase
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

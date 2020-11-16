using DankseIt.MuncipalityTax.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public class TaxCalculationStrategy : ITaxCalculationStrategy
    {
        private TaxStrategy _taxStrategy;

        public void SetSortStrategy(TaxStrategy taxStrategy)
        {
            _taxStrategy = taxStrategy;
        }
        public double ProcessTax(DateTime date, MuncipalTax tax)
        {
            return _taxStrategy.ProcessTax(date, tax);
        }
    }
}

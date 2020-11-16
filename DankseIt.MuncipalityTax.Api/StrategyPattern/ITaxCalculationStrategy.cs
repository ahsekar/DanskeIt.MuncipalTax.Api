using DankseIt.MuncipalityTax.Api.Models;
using System;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public interface ITaxCalculationStrategy
    {
        public double ProcessTax(DateTime date, MuncipalTax tax);
        public void SetSortStrategy(TaxStrategy taxStrategy);
    }
}
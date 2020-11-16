using DankseIt.MuncipalityTax.Api.Models;
using System;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public abstract class TaxStrategy
    {
        public abstract double ProcessTax(DateTime date, MuncipalTax muncipalTax);
    }
}

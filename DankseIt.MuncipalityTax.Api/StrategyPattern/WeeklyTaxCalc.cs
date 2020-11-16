using DankseIt.MuncipalityTax.Api.Models;
using System;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public class WeeklyTaxCalc : TaxStrategy
    {
        public override double ProcessTax(DateTime date, MuncipalTax muncipalTax)
        {
            var taxAmount = 0.0;
            if (date >= Convert.ToDateTime(muncipalTax.WeeklyTax.FromDate) && date <= Convert.ToDateTime(muncipalTax.WeeklyTax.ToDate))
            {
                taxAmount = muncipalTax.WeeklyTax.TaxAmount;
            }
            return taxAmount;
        }
    }

}

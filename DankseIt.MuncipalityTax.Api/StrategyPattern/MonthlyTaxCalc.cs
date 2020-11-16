using DankseIt.MuncipalityTax.Api.Models;
using System;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public class MonthlyTaxCalc : TaxStrategy
    {
        public override double ProcessTax(DateTime date, MuncipalTax muncipalTax)
        {
            var taxAmount = 0.0;
            if (date >= Convert.ToDateTime(muncipalTax.MonthlyTax.FromDate) && date <= Convert.ToDateTime(muncipalTax.MonthlyTax.ToDate))
            {
                taxAmount = muncipalTax.WeeklyTax.TaxAmount;
            }
            return taxAmount;
        }
    }

}

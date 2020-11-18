using DankseIt.MuncipalityTax.Api.Models;
using System;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public class YearlyTaxCalc : TaxStrategy
    {
        public override double ProcessTax(DateTime date, MuncipalTax muncipalTax)
        {
            double taxAmount = 0;
            if (muncipalTax?.YearlyTax != null)
            {
                if (date >= Convert.ToDateTime(muncipalTax?.YearlyTax.FromDate) && date <= Convert.ToDateTime(muncipalTax?.YearlyTax.ToDate))
                    taxAmount = muncipalTax.YearlyTax.TaxAmount;
            }
            return taxAmount;
        }
    }

}

using DankseIt.MuncipalityTax.Api.Models;
using System;
using System.Linq;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public class DailyTaxCalc : TaxStrategy
    {
        public override double ProcessTax(DateTime date, MuncipalTax muncipalTax)
        {
            double taxAmount = 0;
            if (muncipalTax?.DailyTax != null)
            {
                var dateList = muncipalTax?.DailyTax?.Dates?.Split(',')?.ToList();
                foreach (var item in dateList)
                {
                    if (date == DateTime.Parse(item))
                    {
                        taxAmount = muncipalTax.DailyTax.TaxAmount;
                        break;
                    }
                }
            }
            return taxAmount;
        }
    }

}

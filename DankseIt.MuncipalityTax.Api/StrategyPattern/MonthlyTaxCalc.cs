﻿using DankseIt.MuncipalityTax.Api.Models;
using System;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public class MonthlyTaxCalc : TaxStrategy
    {
        public override double ProcessTax(DateTime date, MuncipalTax muncipalTax)
        {
            double taxAmount = 0;
            if (muncipalTax?.MonthlyTax != null)
            {
                if (date >= Convert.ToDateTime(muncipalTax?.MonthlyTax?.FromDate) && date <= Convert.ToDateTime(muncipalTax?.MonthlyTax?.ToDate))
                    taxAmount = muncipalTax.MonthlyTax.TaxAmount;
            }
            return taxAmount;
        }
    }

}

﻿using DankseIt.MuncipalityTax.Api.Models;
using System;

namespace DankseIt.MuncipalityTax.Api.StrategyPattern
{
    public class WeeklyTaxCalc : TaxStrategy
    {
        public override double ProcessTax(DateTime date, MuncipalTax muncipalTax)
        {
            double taxAmount = 0;
            if (muncipalTax?.WeeklyTax != null)
            {
                if (date >= Convert.ToDateTime(muncipalTax?.WeeklyTax?.FromDate) && date <= Convert.ToDateTime(muncipalTax?.WeeklyTax?.ToDate))
                    taxAmount = muncipalTax.WeeklyTax.TaxAmount;
            }
            return taxAmount;
        }
    }

}

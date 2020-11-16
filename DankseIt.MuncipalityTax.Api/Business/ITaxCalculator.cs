using System;
using System.Threading.Tasks;

namespace DankseIt.MuncipalityTax.Api.Business
{
    public interface ITaxCalculator
    {
        Task<double> CalculateTax(string muncipality, string dateTime);
        Task<bool> CreateTax(string values);
    }
}
using System;
using System.Threading.Tasks;

namespace DankseIt.MuncipalityTax.Api.Business
{
    public interface ITaxCalculator
    {
        Task<double> CalculateTax(string muncipality, DateTime dateTime);
        Task<bool> CreateTax(string values);
    }
}
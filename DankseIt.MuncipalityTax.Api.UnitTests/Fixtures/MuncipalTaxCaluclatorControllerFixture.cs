namespace DankseIt.MuncipalityTax.Api.UnitTests.Fixture
{
    using DankseIt.MuncipalityTax.Api.Business;
    using DankseIt.MuncipalityTax.Api.Controllers;
    using DankseIt.MuncipalityTax.Api.StrategyPattern;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.PlatformAbstractions;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class MuncipalTaxCaluclatorControllerFixture
    {
        public readonly Mock<ILogger<MuncipalTaxCaluclatorController>> controllerLoggerMock;
        public readonly Mock<ILogger<TaxCalculator>> taxCalculatorLoggerMock;
        public readonly TaxCalculator _taxCalulator;
        public readonly TaxCalculationStrategy strategy;
        public IMemoryCache InMemoryCache;

        public MuncipalTaxCaluclatorControllerFixture()
        {
            controllerLoggerMock = new Mock<ILogger<MuncipalTaxCaluclatorController>>();
            taxCalculatorLoggerMock = new Mock<ILogger<TaxCalculator>>();
            InMemoryCache = new MemoryCache(new MemoryCacheOptions { });
            strategy = new TaxCalculationStrategy();
            _taxCalulator = new TaxCalculator(taxCalculatorLoggerMock.Object, InMemoryCache, strategy);
        }

        public string GetJsonData(string muncipality)
        {
            using StreamReader r = new StreamReader(muncipality + "Tax.json");
            string json = r.ReadToEnd();
            return json;
        }
    }
}
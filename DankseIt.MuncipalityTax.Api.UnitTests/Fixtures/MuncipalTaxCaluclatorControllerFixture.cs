namespace DankseIt.MuncipalityTax.Api.UnitTests.Fixture
{
    using DankseIt.MuncipalityTax.Api.Business;
    using DankseIt.MuncipalityTax.Api.Controllers;
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
        public IMemoryCache InMemoryCache;

        public MuncipalTaxCaluclatorControllerFixture()
        {
            controllerLoggerMock = new Mock<ILogger<MuncipalTaxCaluclatorController>>();
            taxCalculatorLoggerMock = new Mock<ILogger<TaxCalculator>>();
            InMemoryCache = new MemoryCache(new MemoryCacheOptions { });
            _taxCalulator = new TaxCalculator(taxCalculatorLoggerMock.Object, InMemoryCache);
        }

        public string GetJsonData()
        {
            using StreamReader r = new StreamReader("CreateTaxSample.json");
            string json = r.ReadToEnd();
            return json;
        }
    }
}
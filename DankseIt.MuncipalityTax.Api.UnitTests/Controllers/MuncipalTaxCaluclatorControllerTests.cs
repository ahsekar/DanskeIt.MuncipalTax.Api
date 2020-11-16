namespace DankseIt.MuncipalityTax.Api.UnitTests.Controllers
{
    using DankseIt.MuncipalityTax.Api.Business;
    using DankseIt.MuncipalityTax.Api.Controllers;
    using DankseIt.MuncipalityTax.Api.UnitTests.Fixture;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class MuncipalTaxCaluclatorControllerTests : IClassFixture<MuncipalTaxCaluclatorControllerFixture>
    {
        private readonly MuncipalTaxCaluclatorControllerFixture _fixture;
        private readonly MuncipalTaxCaluclatorController _controller;

        public MuncipalTaxCaluclatorControllerTests(MuncipalTaxCaluclatorControllerFixture fixture)
        {
            _fixture = fixture;
            _controller = new MuncipalTaxCaluclatorController(fixture._taxCalulator, _fixture.controllerLoggerMock.Object);
        }
     
        [Fact]
        public async void GivenValidMuncipalityDetails_WhenInvokedApi_Return200()
        {
            var input = _fixture.GetJsonData();
            var output = await _controller.Post(input) as ObjectResult;
            Assert.NotNull(output);
            Assert.Equal(output.StatusCode.Value, StatusCodes.Status200OK);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("Invalid json")]
        public async void GivenInvalidValidMuncipalityDetails_WhenInvokedApi_ReturnBadRequest(string data)
        {
            var input = data;
            var output = await _controller.Post(input) as ObjectResult;
            Assert.NotNull(output);
            Assert.Equal(output.StatusCode.Value, StatusCodes.Status400BadRequest);
        }
    }
}
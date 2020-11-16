namespace DankseIt.MuncipalityTax.Api.UnitTests.Controllers
{
    using DankseIt.MuncipalityTax.Api.Controllers;
    using DankseIt.MuncipalityTax.Api.UnitTests.Fixture;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System;
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

        #region CreateEndPoint

        [Fact]
        public async void GivenValidMuncipalityDetails_WhenInvokedApi_Return200()
        {
            var input = _fixture.GetJsonData("SanAnders");
            var output = await _controller.Post(input) as ObjectResult;
            Assert.NotNull(output);
            Assert.Equal(output.StatusCode.Value, StatusCodes.Status200OK);
            _fixture.taxCalculatorLoggerMock.Verify(
            m => m.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((object v, Type _) => v.ToString().Contains("Create tax for muncipality")),
            It.IsAny<Exception>(),
            (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));
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

        #endregion

        #region GetEndPoint

        [Theory]
        [InlineData("Brazil", "07/07/2020")]//Testcase for dailyTax
        [InlineData("Brazil", "14/07/2020")]//Testcase for weeklyTax
        [InlineData("Brazil", "02/05/2020")]//Testcase for MonthlyTax
        [InlineData("Brazil", "09/09/2020")]//Testcase for YearlyTax
        public async void GivenValidMuncipalityAndDate_WhenGetEndpointIsInvoked_ReturntaxValue(string muncipality, string data)
        {
            var input = _fixture.GetJsonData(muncipality);
            await _controller.Post(input);
            var output = await _controller.Get(muncipality, data) as ObjectResult;
            Assert.NotNull(output);
            Assert.Equal(output.StatusCode.Value, StatusCodes.Status200OK);
        }

        [Theory]
        [InlineData("California", "07/07/2020")]
        [InlineData("Brazil", "Invalid Input")]
        [InlineData("Brazil", null)]
        [InlineData(null, null)]
        public async void GivenInvalidMuncipalityAndDate_WhenGetEndpointIsInvoked_ReturnBadRequest(string muncipality, string data)
        {
            if (data == "Brazil")
            {
                var input = _fixture.GetJsonData(muncipality);
                await _controller.Post(input);
            }
            var output = await _controller.Get(muncipality, data) as ObjectResult;
            Assert.NotNull(output);
            Assert.Equal(output.StatusCode.Value, StatusCodes.Status400BadRequest);
        }

        #endregion

    }
}
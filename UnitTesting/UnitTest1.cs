using Newtonsoft.Json;
using NT_TDD_Algoritmi;
using System;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace UnitTesting
{
    public class UnitTest1
    {
        // JSON string for the tests
        string data = (@" { ""prices"": [ { ""price"": 13.494, ""startDate"": ""2022-11-14T22:00:00.000Z"", ""endDate"": ""2022-11-14T23:00:00.000Z"" }, { ""price"": 17.62, ""startDate"": ""2022-11-14T21:00:00.000Z"", ""endDate"": ""2022-11-14T22:00:00.000Z"" } ] }");


        [Fact]
        public void DeserializeDataFromJSON()
        {
            List<ElectricPrice> ElectricPriceList = Calculator.DeserializePrices(data);

            // Checks that there are 2 items in the list (two prices)
            Assert.Equal(2, ElectricPriceList.Count);

            // Checks that values match with the JSON data
            Assert.Equal( 13.494m, ElectricPriceList[0].Price);
            Assert.Equal(new DateTime(2022, 11, 14, 22, 0, 0), ElectricPriceList[0].StartDate);
            Assert.Equal(new DateTime(2022, 11, 14, 23, 0, 0), ElectricPriceList[0].EndDate);
            Assert.Equal(17.62m, ElectricPriceList[1].Price);
            Assert.Equal(new DateTime(2022, 11, 14, 21, 0, 0), ElectricPriceList[1].StartDate);
            Assert.Equal(new DateTime(2022, 11, 14, 22, 0, 0), ElectricPriceList[1].EndDate);
        }

        [Theory]
        [InlineData(0, -13.494)]
        [InlineData(13.494, 0)]
        [InlineData(15.494, 2)]
        public void PriceDifference_ShouldReturnCorrectResult(decimal a, decimal expected)
        {
            List<ElectricPrice> ElectricPriceList = Calculator.DeserializePrices(data);

            decimal priceDifference = Calculator.CalculatePriceDifference(a, ElectricPriceList[0]);
            Assert.Equal(priceDifference, expected);

        }

        [Theory]
        [InlineData(0, "Kiinteäsähkö on edullisempi")]
        [InlineData(13.494, "Pörssisähkö ja kiinteäsähkö ovat saman hintaiset")]
        [InlineData(15.494, "Pörssisähkö on edullisempi")]
        public void CheaperOption_ShouldReturnCorrectResult(decimal a, string expected)
        {
            List<ElectricPrice> ElectricPriceList = Calculator.DeserializePrices(data);

            string cheaperContractText = Calculator.WhichContractIsCheaper(a, ElectricPriceList[0]);

            Assert.Equal(cheaperContractText, expected);
        }



    }
}
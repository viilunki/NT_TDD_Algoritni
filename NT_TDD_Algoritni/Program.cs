// See https://aka.ms/new-console-template for more information
using NT_TDD_Algoritmi;

string data = (@" { ""prices"": [ { ""price"": 13.494, ""startDate"": ""2022-11-14T22:00:00.000Z"", ""endDate"": ""2022-11-14T23:00:00.000Z"" }, { ""price"": 17.62, ""startDate"": ""2022-11-14T21:00:00.000Z"", ""endDate"": ""2022-11-14T22:00:00.000Z"" } ] }");
List<ElectricPrice> ElectricPriceList = Calculator.DeserializePrices(data);

Console.WriteLine("Pörssisähkön hinta " + ElectricPriceList[0].StartDate + " - " + ElectricPriceList[0].EndDate + " välisellä tunnilla on " + ElectricPriceList[0].Price);

decimal FixedPrice = 13.000m;
Console.WriteLine("Kiinteän sähkön hinta on " + FixedPrice);

string CheapestContractIs = Calculator.WhichContractIsCheaper(FixedPrice, ElectricPriceList[0]);
Console.WriteLine(CheapestContractIs);
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_TDD_Algoritmi
{
    public static class Calculator
    {
        public static List<ElectricPrice> DeserializePrices(string jsondata)
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsondata);
            DataTable dataTable = dataSet.Tables["prices"];

            var list = new List<ElectricPrice>();

            foreach (DataRow row in dataTable.Rows)
            {
                decimal price = Convert.ToDecimal(row["price"]);
                DateTime startDate = Convert.ToDateTime(row["startDate"]);
                DateTime endDate = Convert.ToDateTime(row["endDate"]);

                Console.WriteLine(row["price"] + " - " + row["startDate"]);

                var newPriceDifferenceItem = new ElectricPrice(price, startDate, endDate);
                list.Add(newPriceDifferenceItem);
            }
            return list;
        }

        public static decimal CalculatePriceDifference(decimal FixedPrice, ElectricPrice electricPrice)
        {
            decimal Difference = FixedPrice - electricPrice.Price;
            return Difference;
        }

        public static string WhichContractIsCheaper(decimal FixedPrice, ElectricPrice electricPrice)
        {
            decimal Difference = CalculatePriceDifference(FixedPrice, electricPrice);
            if (Difference > 0)
            {
                return "Pörssisähkö on edullisempi";
            }
            else if(Difference < 0)
            {
                return "Kiinteäsähkö on edullisempi";
            }
            else
            {
                return "Pörssisähkö ja kiinteäsähkö ovat saman hintaiset";
            }
        }

    }
}

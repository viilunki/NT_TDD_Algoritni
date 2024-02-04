using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_TDD_Algoritmi
{
    public enum ElectricityContractType
    {
        FixedPrice,
        MarketPrice
    }

    public class PriceDifference
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PriceDifferenceValue { get; set; }
        public ElectricityContractType CheaperContract { get; set; }

        public PriceDifference(DateTime startDate, DateTime endDate, decimal priceDifference, ElectricityContractType cheaperContract)
        {
            StartDate = startDate;
            EndDate = endDate;
            PriceDifferenceValue = priceDifference;
            CheaperContract = cheaperContract;
        }
    }
}

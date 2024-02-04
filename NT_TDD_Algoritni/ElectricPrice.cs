using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT_TDD_Algoritmi
{
    public class ElectricPrice
    {
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ElectricPrice(decimal price, DateTime startDate, DateTime endDate)
        {
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}

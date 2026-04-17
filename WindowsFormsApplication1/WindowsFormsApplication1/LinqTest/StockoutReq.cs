using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.LinqTest
{
    public class StockoutReq
    {
        public int Id { get; set; }
        public string ReqNumber { get; set; }
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
    }
}

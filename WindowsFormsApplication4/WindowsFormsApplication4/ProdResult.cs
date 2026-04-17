using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    public class ProdResult
    {
        public ProdResult() { }
        public ProdResult(string itemCode, string barcode, decimal qty)
        {
            ItemCode = itemCode;
            Barcode = barcode;
            Qty = qty;
        }

        public string ItemCode { get; set; }

        public string Barcode { get; set; }

        public decimal Qty { get; set; }
        
        public bool Equals(ProdResult other)
        {
            if (other == null) return false;
            return string.Equals(ItemCode, other.ItemCode, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(Barcode, other.Barcode, StringComparison.OrdinalIgnoreCase);
        }
    }
}

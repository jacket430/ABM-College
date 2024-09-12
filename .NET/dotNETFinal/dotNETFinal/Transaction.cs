using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace dotNETFinal
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int PropertyID { get; set; }
        public int OwnerID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}

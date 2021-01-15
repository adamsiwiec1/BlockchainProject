using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainApplication.BlockChain
{
    public class Transaction
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public int Amount { get; set; }

        public Transaction() { }
    }
}

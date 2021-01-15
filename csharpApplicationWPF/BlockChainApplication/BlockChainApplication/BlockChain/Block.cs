using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainApplication.BlockChain
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int Proof { get; set; }
        public string PreviousHash { get; set; }

        public override string ToString()
        {
            return $"Index: {Index} \nTime:[{Timestamp.ToString("yyyy-MM-dd HH:mm:ss")}] \nProof: {Proof} \nPrevHash: {PreviousHash} \nTrxCount: {Transactions.Count}";
        }
    }
}

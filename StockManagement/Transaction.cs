using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public abstract class Transaction
    {
        private DateTime transactionDatetime;
        public DateTime TransactionDatetime
        {
            get { return transactionDatetime;} 
            set {}
        }
        private string transactionName;
        public string TransactionName
        {
            get { return transactionName; }
            set { }
        }

        public Transaction(string name, DateTime dt)
        {
            this.transactionName = name;
            this.transactionDatetime = dt;
        }

        public DateTime GetTransactionDatetime()
        {
            return transactionDatetime;
        }
        public string GetTransactionName() 
        {
            return transactionName;
        }

        public abstract string ToString();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class ItemDeletedTransaction:Transaction
    {
        private int stockItemCode;
        private string stockItemName;

        public ItemDeletedTransaction(DateTime transitionDateTime, int stockItemCode, string stockItemName)
            :base("Item deleted", transitionDateTime)
        {
            this.stockItemCode = stockItemCode;
            this.stockItemName = stockItemName;
        }

        public override string ToString()
        {
            return (this.GetTransactionDatetime().ToString("dd/MM/yyyy HH:mm") + " Item deleted     - Item " + this.stockItemCode + ": " + this.stockItemName + " deleted.");
        }
    }
}

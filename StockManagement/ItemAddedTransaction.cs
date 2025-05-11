using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class ItemAddedTransaction:Transaction
    {
        private int stockItemCode;
        private string stockItemName;
        private int quantityAdded;

        public ItemAddedTransaction(DateTime transitionDateTime, int stockItemCode, string stockItemName, int quantityAdded)
        : base("Item added", transitionDateTime)
        {
            this.stockItemCode = stockItemCode;
            this.stockItemName = stockItemName;
            this.quantityAdded = quantityAdded;
        }

        public override string ToString()
        {
            return (this.GetTransactionDatetime().ToString("dd/MM/yyyy HH:mm") + " Item added       - Item "+ this.stockItemCode + ": " + this.stockItemName + " added. Quantity in stock: " + this.quantityAdded);
        }
    }
}

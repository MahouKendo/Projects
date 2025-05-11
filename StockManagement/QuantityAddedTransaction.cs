using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class QuantityAddedTransaction:Transaction
    {
        private int stockItemCode;
        private string stockItemName;
        private int quantityAdded;
        private int newQuantityInStock;

        public QuantityAddedTransaction(DateTime transitionDateTime, int stockItemCode, string stockItemName, int quantityAdded, int newQuantityInStock)
        : base("Quantity added", transitionDateTime)
        {
            this.stockItemCode = stockItemCode;
            this.stockItemName = stockItemName;
            this.quantityAdded = quantityAdded;
            this.newQuantityInStock = newQuantityInStock;
        }

        public override string ToString()
        {
            return (this.GetTransactionDatetime().ToString("dd/MM/yyyy HH:mm") + " Quantity added   - Item " + this.stockItemCode + ": " + this.stockItemName + ". Quantity added: " + this.quantityAdded + ". New quantity in stock: " + this.newQuantityInStock);
        }
    }
}

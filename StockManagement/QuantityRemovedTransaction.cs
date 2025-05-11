using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class QuantityRemovedTransaction:Transaction
    {
        private int stockItemCode;
        private string stockItemName;
        private int quantityRemoved;
        private int newQuantityInStock;

        public QuantityRemovedTransaction(DateTime transitionDateTime, int stockItemCode, string stockItemName, int quantityRemoved, int newQuantityInStock)
        : base("Quantity removed", transitionDateTime)
        {
            this.stockItemCode = stockItemCode;
            this.stockItemName = stockItemName;
            this.quantityRemoved = quantityRemoved;
            this.newQuantityInStock = newQuantityInStock;
        }

        public override string ToString()
        {
            return (this.GetTransactionDatetime().ToString("dd/MM/yyyy HH:mm") + " Quantity removed - Item " + this.stockItemCode + ": " + this.stockItemName + ". Quantity removed: " + this.quantityRemoved + ". New quantity in stock: " + this.newQuantityInStock);
        }
    }
}

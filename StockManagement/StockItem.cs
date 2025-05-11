using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class StockItem
    {
        private int code;
        private string name;
        private int quantityInStock;

        public int Code 
        { 
            get { return code; } 
            set{}
        }
        public string Name 
        {
            get { return name; }
            set {}
        }
        public int QuantityInStock 
        { 
            get { return quantityInStock; }
            set {}
        }

        public StockItem(int code, string name, int qtyInStock)
        {
            switch (name) 
            {
                case "" when code < 0 && qtyInStock <= 0:
                    throw new Exception("Item code must be a positive integer. Item name cannot be blank. Quantity cannot be zero or negative. ");
                case "":
                    throw new Exception("Item name cannot be blank. ");
            }

            if (string.IsNullOrWhiteSpace(name) == true && code < 0)
            {
                throw new Exception("Item code must be a positive integer. Item name cannot be just spaces. ");
            }

            else if (string.IsNullOrWhiteSpace(name) == true)
            {
                throw new Exception("Item name cannot be just spaces. ");
            }

            else
            {
                this.name = name;
            }

            switch (code) 
            {
                case int n when n < 0:
                    throw new Exception("Item code must be a positive integer. ");
                default:
                    this.code = code;
                    break;
            }

            switch (qtyInStock)
            {
                case int n when n <= 0:
                    throw new Exception("Quantity cannot be zero or negative. ");
                default:
                    this.quantityInStock = qtyInStock;
                    break;
            }

        }

        public void AddQuantity(int qty)
        {
            if (qty < 0)
            {
                throw new Exception("Quantity cannot be negative");
            }
            this.quantityInStock += qty;
        }

        public void SubtractQuantity(int qty)
        {
            if (qty < 0)
            {
                throw new Exception("Quantity cannot be negative");
            }
            this.quantityInStock -= qty;
            if (this.quantityInStock < 0)
            {
                this.quantityInStock += qty;
                throw new Exception("Insufficient quantity in stock");
            }
        }

        public int GetCode()
        {
            return code;
        }

        public string GetName()
        {
            return name;
        }

        public int GetQuantityInStock()
        {
            return quantityInStock;
        }


    }
}


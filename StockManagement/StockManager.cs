using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace StockManagement
{
    public class StockManager
    {
        private SortedDictionary<int, StockItem> stockItems = new SortedDictionary<int, StockItem>();

        public StockItem AddQuantityToStockItem(int code, int quantityToAdd)
        {
            foreach(int codes in stockItems.Keys)
            {
                if(codes == code)
                {
                    stockItems[codes].AddQuantity(quantityToAdd);
                    return stockItems[codes];
                }
            }
            throw new Exception("Stock item " + code + " not found. Quantity not added.");
        }

        public StockItem CreateStockItem(int code, string name, int quantityInStock) 
        {
            if (stockItems.ContainsKey(code))
            {
                throw new Exception("Item code " + code + " already exists. Item not added.");
            }
            StockItem stockitem = new StockItem(code, name, quantityInStock);
            if (stockItems.ContainsValue(stockitem))
            {
                throw new Exception("StockItem is already exit");
            }
            else
            {
                stockItems.Add(code, stockitem);
                return stockitem;
            }
        }

        public StockItem DeleteStockItem(int code)
        {
            foreach(int codes in stockItems.Keys)
            {
                if (codes == code)
                {
                    if (stockItems[codes].QuantityInStock > 0)
                    {
                        throw new Exception("Item cannot be deleted because quantity in stock is not zero");
                    }
                    StockItem del_stock = stockItems[codes];
                    stockItems.Remove(codes);
                    return del_stock;
                }
            }
            throw new Exception("Item has not been deleted because it cannot be found");
        }

        public StockItem FindStockItem(int code)
        {
            foreach (int codes in stockItems.Keys)
            {
                if (codes == code)
                {
                    return stockItems[codes];
                }
            }
            return null;
        }

        public SortedDictionary<int, StockItem> GetAllStockItems() 
        {
            return stockItems;
        }

        public StockItem RemoveQuantityFromStockItem(int code, int quantityToAdd)
        {
            foreach (int codes in stockItems.Keys)
            {
                if (codes == code)
                {
                    stockItems[codes].SubtractQuantity(quantityToAdd);
                    return stockItems[codes];
                }
            }
            throw new Exception("Stock item " + code + " not found. Quantity not removed.");
        }
    }
}

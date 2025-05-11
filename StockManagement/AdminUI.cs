using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace StockManagement
{
    public class AdminUI
    {
        private StockManager stockMgr;
        private TransactionManager TransactionMgr;

        public AdminUI(StockManager stkMgr, TransactionManager trMgr) 
        {
            this.stockMgr = stkMgr;
            this.TransactionMgr = trMgr;
        }

        public List<string> AddANewItemOfStock(int code, string name, int quantityInStock)
        {
            try
            {
                StockItem stock = this.stockMgr.CreateStockItem(code, name, quantityInStock);
                this.TransactionMgr.RecordItemAdded(stock);
                List<string> result = new List<string>();
                result.Add("Item added. Item code: " + code);
                return result;
            }
            catch(Exception e) 
            {
                List<string> result = new List<string>();
                result.Add(e.Message);
                return result;
            }
        }

        public List<string> AddQuantityToAStockItem(int code, int quantityToAdd)
        {
            try 
            {
                StockItem stock = this.stockMgr.AddQuantityToStockItem(code, quantityToAdd);
                this.TransactionMgr.RecordQuantityAdded(stock, quantityToAdd);
                List<string> result = new List<string>();
                result.Add("Quantity added to item: " + code + ". New quantity in stock: " + stock.QuantityInStock);
                return result;
            }
            catch(Exception e) 
            {
                List<string> result = new List<string>();
                result.Add(e.Message);
                return result;
            }
        }

        public List<string> DeleteAStockItem(int code) 
        {
            try
            {
                StockItem stock = this.stockMgr.DeleteStockItem(code);
                this.TransactionMgr.RecordItemDeleted(stock);
                List<string> result = new List<string>();
                result.Add("Item " + code + " deleted.");
                return result;
            }
            catch (Exception e)
            {
                List<string> result = new List<string>();
                result.Add(e.Message);
                return result;
            }
        }

        public List<string> RemoveQuantityFromAStockItem(int code, int quantityToRemoved) 
        {
            try
            {
                StockItem stock = this.stockMgr.RemoveQuantityFromStockItem(code, quantityToRemoved);
                this.TransactionMgr.RecordQuantityRemoved(stock, quantityToRemoved);
                List<string> result = new List<string>();
                result.Add("Quantity removed from item: " + code + ". New quantity in stock: " + stock.QuantityInStock);
                return result;
            }
            catch (Exception e)
            {
                List<string> result = new List<string>();
                result.Add(e.Message);
                return result;
            }
        }

        public List<string> ViewStockLevels()
        {
            SortedDictionary<int, StockItem> stockItems = this.stockMgr.GetAllStockItems();
            if (stockItems.Count == 0)
            {
                List<string> result = new List<string>();
                result.Add("\nStock Levels");
                result.Add("============");
                result.Add("No stock items");
                return result;
            }
            else
            {
                List<string> result = new List<string>();
                result.Add("\nStock Levels");
                result.Add("============");
                result.Add("\tItem code\tItem name           \tQuantity in stock");
                foreach (int item in stockItems.Keys)
                {
                    //string space1 = "        ";
                    string space2 = "                    ";
                    //int begin = item.Length;
                    int begin2 = stockItems[item].Name.Length;
                    space2 = space2.Remove(0, begin2);
                    //space = space.Remove(0, begin);
                    result.Add("\t" + item + "        " + "\t" + stockItems[item].Name + space2 + "\t" + stockItems[item].QuantityInStock);
                }
                return result;
            }
        }

        public List<string> ViewTransactionLog()
        {
            List<Transaction> transactions = this.TransactionMgr.GetAllTransactions();
            if (transactions.Count == 0)
            {
                List<string> result = new List<string>();
                result.Add("\nTransaction log");
                result.Add("===============");
                result.Add("No transactions");
                return result;
            }
            else{
                List<string> result = new List<string>();
                result.Add("\nTransaction log");
                result.Add("===============");
                foreach(Transaction transaction in transactions)
                {
                    result.Add(transaction.ToString());
                }
                return result;

                
            }
        }
    }
}

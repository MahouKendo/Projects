using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class TransactionManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public List<Transaction> GetAllTransactions()
        {
            return transactions; 
        }

        public void RecordItemAdded(StockItem stockItem)
        {
            DateTime now = DateTime.Now;
            Transaction Transaction_added = new ItemAddedTransaction(now, stockItem.Code, stockItem.Name, stockItem.QuantityInStock);
            Transaction_added = (ItemAddedTransaction) Transaction_added;
            transactions.Add(Transaction_added);
        }

        public void RecordItemDeleted(StockItem stockItem)
        {
            DateTime now = DateTime.Now;
            Transaction Transaction_Deleted = new ItemDeletedTransaction(now, stockItem.Code, stockItem.Name);
            Transaction_Deleted = (ItemDeletedTransaction)Transaction_Deleted;
            transactions.Add(Transaction_Deleted);
        }

        public void RecordQuantityAdded(StockItem stockItem, int quantityAdded)
        {
            DateTime now = DateTime.Now;
            Transaction Transaction_Quanity_added = new QuantityAddedTransaction(now, stockItem.Code, stockItem.Name, quantityAdded, stockItem.QuantityInStock);
            Transaction_Quanity_added = (QuantityAddedTransaction)Transaction_Quanity_added;
            transactions.Add(Transaction_Quanity_added);
        }
        
        public void RecordQuantityRemoved(StockItem stockItem, int quantityRemoved)
        {
            DateTime now = DateTime.Now;
            Transaction Transaction_Quanity_Removed = new QuantityRemovedTransaction(now, stockItem.Code, stockItem.Name, quantityRemoved, stockItem.QuantityInStock);
            Transaction_Quanity_Removed = (QuantityRemovedTransaction)Transaction_Quanity_Removed;
            transactions.Add(Transaction_Quanity_Removed);
        }
    }
}

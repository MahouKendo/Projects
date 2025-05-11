using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;

namespace StockManagement
{
    class Program
    {
        private static AdminUI adminUI;

        public static void Main(string[] args)
        {
            StockManager stockmg = new StockManager();
            TransactionManager transactionmgr = new TransactionManager();
            adminUI = new AdminUI(stockmg, transactionmgr);
            Console.WriteLine("\n\tWrite your Stock Management application in this project." +
                "\n\n\tFollow the instructions in the assignment specification." +
                "\n\n\tREMEMBER: do not change any of the code in the tests project." +
                "\n\n\tYou can delete the code in the Main() method.\n\n");
            while (true)
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Option: ");
                    int option = ReadInterger(Console.ReadLine());
                    if (option == -1)
                    {
                        Console.WriteLine("===================================================");
                        Console.WriteLine("Quiting......................");
                        break;
                    }
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("===================================================");
                            AddANewItemOfStockItem();
                            break;
                        case 2:
                            Console.WriteLine("===================================================");
                            DeleteAStockItem();
                            break;
                        case 3:
                            Console.WriteLine("===================================================");
                            AddQuantityToAStockItem();
                            break;
                        case 4:
                            Console.WriteLine("===================================================");
                            RemoveQuantityFromAStockItem();
                            break;
                        case 5:
                            Console.WriteLine("===================================================");
                            ViewStockLevels();
                            break;
                        case 6:
                            Console.WriteLine("===================================================");
                            ViewTransactionLog();
                            break;
                        default:
                            Console.WriteLine("===================================================");
                            Console.WriteLine("Must enter interger from 1 to 6 or -1 to Quit");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("===================================================");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("Enter 1 to Add StockItem\n" +
                              "Enter 2 to Removed StockItem\n" +
                              "Enter 3 to Add Quantity to StockItem\n" +
                              "Enter 4 to Subtract Quantity from StockItem\n" +
                              "Enter 5 to ViewStockLevels\n" +
                              "Enter 6 toViewTransactionLog\n" +
                              "Enter -1 to Quit the Program");
            Console.WriteLine("===================================================");
        }


        private static void DisplayResults(List<string> result)
        {
            Console.WriteLine("===================================================");
            foreach (string resultItem in result)
            {
                Console.WriteLine($"{resultItem}");
            }
        }

        private static int ReadInterger(string prompt)
        {
            try
            {
                int check = Convert.ToInt32(prompt);
                return check;
            }
            catch (Exception)
            {
                throw new Exception("Must enter a interger");
            }
        }

        private static string ReadString(string prompt)
        {
            return prompt;
        }

        private static void AddANewItemOfStockItem()
        {
            try
            {
                Console.Write("Enter the Stock Code: ");
                int code = ReadInterger(Console.ReadLine());
                Console.Write("Enter the Stock Name: ");
                string name = ReadString(Console.ReadLine());
                Console.Write("Enter the Stock Quantity: ");
                int quantity = ReadInterger(Console.ReadLine());
                List<string> result = adminUI.AddANewItemOfStock(code, name, quantity);
                DisplayResults(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void AddQuantityToAStockItem()
        {
            try
            {
                Console.Write("Enter the Stock Code you wish to Add Quantity: ");
                int code = ReadInterger(Console.ReadLine());
                Console.Write("Enter the amount of Quantity you wish to Add: ");
                int quantity = ReadInterger(Console.ReadLine());
                List<string> result = adminUI.AddQuantityToAStockItem(code, quantity);
                DisplayResults(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void DeleteAStockItem()
        {
            try
            {
                Console.Write("Enter the Stock Code you wish to Delete: ");
                int code = ReadInterger(Console.ReadLine());
                List<string> result = adminUI.DeleteAStockItem(code);
                DisplayResults(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void RemoveQuantityFromAStockItem()
        {
            try
            {
                Console.Write("Enter the Stock Code you wish to Add Quantity: ");
                int code = ReadInterger(Console.ReadLine());
                Console.Write("Enter the amount of Quantity you wish to Add: ");
                int quantity = ReadInterger(Console.ReadLine());
                List<string> result = adminUI.RemoveQuantityFromAStockItem(code, quantity);
                DisplayResults(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ViewStockLevels()
        {
            List<string> result = adminUI.ViewStockLevels();
            DisplayResults(result);
        }

        private static void ViewTransactionLog()
        {
            List<string> result = adminUI.ViewTransactionLog();
            DisplayResults(result);
        }
    }
}
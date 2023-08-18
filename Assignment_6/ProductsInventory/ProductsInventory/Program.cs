using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProductsInventory
{
    internal class Program
    {     
        static void Main(string[] args)
        {
            Produts products = new Produts();
            char choice;
            do
            {
                Console.WriteLine("Enter your choice\n1. Read\n2. Insert\n3. Update" +
                    "\n4. Delete");
                int op = int.Parse(Console.ReadLine());
                
                switch (op)
                {
                    case 1:
                        products.ReaderMethod();
                        break;
                    case 2:
                        products.InsertMethod();
                        break;
                    case 3:
                        products.UpdateMethod();
                        break;
                    case 4:
                        products.DeleteMethod();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("Do you wanna continue the operation\n" +
                    "If yes press 'y' or press any key");
                choice = char.Parse(Console.ReadLine());
            } while (choice == 'y' || choice == 'Y');
                                
        }
    }  
}

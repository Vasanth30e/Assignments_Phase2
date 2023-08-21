using System;

namespace CRUDOperations_DisconnectedModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUD_Operations_Disconnected operation = new CRUD_Operations_Disconnected();
            char choice;

            do
            {
                Console.WriteLine("Enter your choice\n1. Read\n2. Insert\n3. Update\n4. Delete");
                int op = int.Parse(Console.ReadLine());
                
                switch (op)
                {
                    case 1:
                        operation.ReadOperation();
                        break;
                    case 2:
                        operation.InsertOperation();
                        break;
                    case 3:
                        operation.UpdateOperation();
                        break;
                    case 4:
                        operation.DeleteOperation();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
                Console.WriteLine("Do you wish to continue\nIf yes press 'y' or press any key");
                choice = char.Parse(Console.ReadLine().ToLower());
            } while (choice == 'y');
            
        }
    }
}

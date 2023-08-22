using System;

namespace CRUD_Operations_Entity_Framework
{
    internal class Program
    {       
        static void Main(string[] args)
        {          
            char choice;
            do
            {
                Console.WriteLine("\nEnter your choice\n1. Employees Table\n2. Products Table\n3. Orders Table");
                int op = int.Parse(Console.ReadLine());
                int op2;
                Employees emp = new Employees();
                Products product = new Products();
                Orders order = new Orders();
                switch (op)
                {
                    case 1:
                        Console.WriteLine("\nEmployee Table");
                        Console.WriteLine("1. Read\n2. Insert\n3. Update\n4. Delete");
                        op2 = int.Parse(Console.ReadLine());
                        switch (op2)
                        {
                            case 1:
                                emp.EFRead();
                                break;
                            case 2:
                                emp.EFInsert();
                                break;
                            case 3:
                                emp.EFUpdate();
                                break;
                            case 4:
                                emp.EFDelete();
                                break;
                            default:
                                Console.WriteLine("Wrong Choice!");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nProducts Table");
                        Console.WriteLine("1. Read\n2. Insert\n3. Update\n4. Delete");
                        op2 = int.Parse(Console.ReadLine());
                        switch (op2)
                        {
                            case 1:
                                product.EFRead();
                                break;
                            case 2:
                                product.EFInsert();
                                break;
                            case 3:
                                product.EFUpdate();
                                break;
                            case 4:
                                product.EFDelete();
                                break;
                            default:
                                Console.WriteLine("Wrong Choice!");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nOrders Table");
                        Console.WriteLine("1. Read\n2. Insert\n3. Update\n4. Delete");
                        op2 = int.Parse(Console.ReadLine());
                        switch (op2)
                        {
                            case 1:
                                order.EFRead();
                                break;
                            case 2:
                                order.EFInsert();
                                break;
                            case 3:
                                order.EFUpdate();
                                break;
                            case 4:
                                order.EFDelete();
                                break;
                            default:
                                Console.WriteLine("Wrong Choice!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }               
                Console.WriteLine("\nDo you wish to continue CRUD operations\nIf yes press 'y' or press any key");
                choice = char.Parse(Console.ReadLine().ToLower());
            } while (choice == 'y');

        }
       
    }
}

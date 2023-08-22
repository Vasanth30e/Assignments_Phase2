using System;
using System.Linq;

namespace CRUD_Operations_Entity_Framework
{
    internal class Employees
    {
        static AdvancedDBEntities db;
        public void EFRead()
        {
            try
            {
                db = new AdvancedDBEntities();
                foreach (Employee e in db.Employees)
                {
                    Console.WriteLine("ID: " + e.EmployeeId);
                    Console.WriteLine("First Name: " + e.FirstName);
                    Console.WriteLine("Last Name: " + e.LastName);
                    Console.WriteLine("Date of Birth: " + e.BirthDate);
                    Console.WriteLine("Salary: " + e.Salary);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public void EFInsert()
        {
            try
            {
                db = new AdvancedDBEntities();
                Employee Employee = new Employee();

                Console.WriteLine("Enter ID: ");
                Employee.EmployeeId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter First Name: ");
                Employee.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                Employee.LastName = Console.ReadLine();
                Console.WriteLine("Enter Date of Birth: ");
                Employee.BirthDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Salary: ");
                Employee.Salary = double.Parse(Console.ReadLine());

                db.Employees.Add(Employee);
                db.SaveChanges();

                Console.WriteLine("Employee Record Inserted");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public void EFUpdate()
        {
            try
            {
                db = new AdvancedDBEntities();
                Employee Employee = new Employee();

                Console.WriteLine("Enter ID to Update the details ");
                int id = int.Parse(Console.ReadLine());
                Employee = db.Employees.SingleOrDefault(e => e.EmployeeId == id);

                if (Employee == null)
                {
                    Console.WriteLine($"No such ID {id} exist in Day8DB");
                }
                else
                {
                    Console.WriteLine("Enter New First Name: ");
                    Employee.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter New Last Name: ");
                    Employee.LastName = Console.ReadLine();
                    Console.WriteLine("Enter New Date of Birth: ");
                    Employee.BirthDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter New Salary: ");
                    Employee.Salary = double.Parse(Console.ReadLine());

                    db.SaveChanges();

                    Console.WriteLine("Employeeloyee Record Updated");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }

        public void EFDelete()
        {
            try
            {
                db = new AdvancedDBEntities();
                Employee Employee = new Employee();

                Console.WriteLine("Enter ID to Update the details ");
                int id = int.Parse(Console.ReadLine());
                Employee = db.Employees.SingleOrDefault(e => e.EmployeeId == id);

                if (Employee == null)
                {
                    Console.WriteLine($"No such ID {id} exist in Day8DB");
                }
                else
                {
                    db.Employees.Remove(Employee);
                    db.SaveChanges();

                    Console.WriteLine("Employeeloyee Record Deleted");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}

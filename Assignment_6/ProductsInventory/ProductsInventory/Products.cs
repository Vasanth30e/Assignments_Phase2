using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsInventory
{
    public class Produts
    {
        static public SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string conStr = "server = LAPTOP-S13SEC6B; database = ProductInventoryDB; trusted_connection = true";
        public void ReaderMethod()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Products", con);

                con.Open();
                reader = cmd.ExecuteReader();

                Console.WriteLine("Product Id\tProduct Name\tPrice\tQuantity\tMFDate\t\t\tExpDate");
                while (reader.Read())
                {
                    Console.Write(reader["ProductId"]);
                    Console.Write("\t\t" + reader["ProductName"]);
                    Console.Write("\t\t" + reader["Price"]);
                    Console.Write("\t" + reader["Quantity"]);
                    Console.Write("\t\t" + reader["MFDate"]);
                    Console.Write("\t" + reader["ExpDate"]);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertMethod()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand()
                {
                    CommandText = "insert into Products(ProductName, Price, Quantity, MFDate, ExpDate) " +
                    "values(@pName, @pPrice, @pQuantity, @pMFDate, @pExpDate) ",
                    Connection = con
                };
                Console.WriteLine("Insertion");
                Console.WriteLine("Enter Product Name");
                cmd.Parameters.AddWithValue("@pName", Console.ReadLine());
                Console.WriteLine("Enter Product Price");
                cmd.Parameters.AddWithValue("@pPrice", double.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product Quantity");
                cmd.Parameters.AddWithValue("@pQuantity", int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product Manufature date");
                cmd.Parameters.AddWithValue("@pMFDate", DateTime.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product Expiry Date");
                cmd.Parameters.AddWithValue("@pExpDate", DateTime.Parse(Console.ReadLine()));

                con.Open();
                int nonQuery = cmd.ExecuteNonQuery();

                if (nonQuery >= 1)
                {
                    Console.WriteLine("Record Inserted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateMethod()
        {
            try
            {
                Console.WriteLine("Enter Product ID to update");
                int id = int.Parse(Console.ReadLine());
                con = new SqlConnection(conStr);
                cmd = new SqlCommand()
                {
                    CommandText = "select * from Products where ProductId = @id",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    con.Close();
                    con.Open();

                    cmd.CommandText = ("update Products set ProductName = @pName, " +
                        "Price = @pPrice, Quantity = @pQuantity, MFDate = @pMFDate," +
                        "ExpDate = @pExpDate where ProductId = @pId");
                    Console.WriteLine("Enter New Product Name");
                    cmd.Parameters.AddWithValue("@pName", Console.ReadLine());
                    Console.WriteLine("Enter New Product Price");
                    cmd.Parameters.AddWithValue("@pPrice", double.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter New Product Quantity");
                    cmd.Parameters.AddWithValue("@pQuantity", int.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter New Product Manufacturing Date");
                    cmd.Parameters.AddWithValue("@pMFDate", DateTime.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter New Product Expiry Date");
                    cmd.Parameters.AddWithValue("@pExpDate", DateTime.Parse(Console.ReadLine()));
                    cmd.Parameters.AddWithValue("@pId", id);  
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record Updated");
                    
                }
                else
                {
                    Console.WriteLine($"No such Id {id} record exist in the table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteMethod()
        {
            try
            {
                Console.WriteLine("Enter the Product Id to delete");
                int id = int.Parse(Console.ReadLine());
                con = new SqlConnection(conStr);
                cmd = new SqlCommand()
                {
                    CommandText = "delete from Products where ProductId = @pId",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@pId", id);
                con.Open();

                int nonQuery = cmd.ExecuteNonQuery();

                if (nonQuery >= 1)
                {
                    Console.WriteLine("Record Deleted");
                }
                else
                {
                    Console.WriteLine($"There is no such Id {id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError!!!" + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}

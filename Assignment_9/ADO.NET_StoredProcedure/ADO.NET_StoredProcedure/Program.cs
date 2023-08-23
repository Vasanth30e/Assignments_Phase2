using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_StoredProcedure
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static string conStr = "server = LAPTOP-S13SEC6B; database = OrderDB; trusted_connection = true;";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                con.Open();

                cmd = new SqlCommand()
                {
                    CommandText = "PlaceOrder",
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                Console.Write("Enter Customer ID : ");
                cmd.Parameters.AddWithValue("@customerId", int.Parse(Console.ReadLine()));
                Console.Write("Enter Total Amount : ");
                cmd.Parameters.AddWithValue("@totalAmount", double.Parse(Console.ReadLine()));

                int output = (int)cmd.ExecuteScalar();

                if (output >= 1)
                {
                    Console.WriteLine("Order Placed Successfully!");
                }
                else
                {
                    Console.WriteLine("Order Placing Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}

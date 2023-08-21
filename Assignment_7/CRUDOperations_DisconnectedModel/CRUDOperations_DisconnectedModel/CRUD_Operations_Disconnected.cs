using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperations_DisconnectedModel
{    
    internal class CRUD_Operations_Disconnected
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;
        static SqlDataReader reader;
        static DataSet ds;
        static string conStr = "server = LAPTOP-S13SEC6B; database = LibraryDB; trusted_connection = true;";

        public void ReadOperation()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Books", con);

                adapter = new SqlDataAdapter(cmd);  //fetch the data from the table

                con.Open();

                ds = new DataSet();   //collection of tables  
                adapter.Fill(ds);     //Used to store the data in the Dataset
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine("Book ID: " + ds.Tables[0].Rows[i]["BookId"]);
                    Console.WriteLine("Title: " + ds.Tables[0].Rows[i]["Title"]);
                    Console.WriteLine("Author: " + ds.Tables[0].Rows[i]["Author"]);
                    Console.WriteLine("Genre: " + ds.Tables[0].Rows[i]["Genre"]);
                    Console.WriteLine("Quantity: " + ds.Tables[0].Rows[i]["Quantity"]);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
            }
            finally
            {
                con.Close();                
            }
        }

        public void InsertOperation()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Books", con);
                adapter = new SqlDataAdapter(cmd);  //fetch the data from the table

                con.Open();

                ds = new DataSet();   //collection of tables  
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();

                Console.WriteLine("Enter Book Id");
                dr["BookId"] = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book Title");
                dr["Title"] = Console.ReadLine();
                Console.WriteLine("Enter Book's Author");
                dr["Author"] = Console.ReadLine();
                Console.WriteLine("Enter Book's Genre");
                dr["Genre"] = Console.ReadLine();
                Console.WriteLine("Enter Book's Quantity");
                dr["Quantity"] = int.Parse(Console.ReadLine());

                dt.Rows.Add(dr);

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                Console.WriteLine("Inserted!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateOperation()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Books", con);
                adapter = new SqlDataAdapter(cmd);  //fetch the data from the table

                con.Open();

                ds = new DataSet();   //collection of tables  
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];
                Console.WriteLine("Enter Book Id to Update");
                int bId = int.Parse(Console.ReadLine());

                DataRow dr = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((int)dt.Rows[i]["BookId"] == bId)
                    {
                        dr = dt.Rows[i];
                        break;
                    }
                }

                if (dr != null)
                {
                    Console.WriteLine("Enter New Book Title");
                    dr["Title"] = Console.ReadLine();
                    Console.WriteLine("Enter Book Author");
                    dr["Author"] = Console.ReadLine();
                    Console.WriteLine("Enter Book Genre");
                    dr["Genre"] = Console.ReadLine();
                    Console.WriteLine("Enter Book Quantity");
                    dr["Quantity"] = int.Parse(Console.ReadLine());

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                    Console.WriteLine("Record Updated!!!");

                }
                else
                {
                    Console.WriteLine($"No such Id {bId} exist in the Customer table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteOperation()
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Books", con);
                adapter = new SqlDataAdapter(cmd);  //fetch the data from the table

                con.Open();

                ds = new DataSet();   //collection of tables  
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];
                Console.WriteLine("Enter Customer Id to delete");
                int bId = int.Parse(Console.ReadLine());

                DataRow dr = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((int)dt.Rows[i]["BookId"] == bId)
                    {
                        dr = dt.Rows[i];
                        break;
                    }
                }

                if (dr != null)
                {
                    dr.Delete();
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                    Console.WriteLine("Record Deleted!!!");

                }
                else
                {
                    Console.WriteLine($"No such Id {bId} exist in the Customer table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!! " + ex.Message);
            }
            finally
            {
                con.Close();        
            }
        }
    }
}

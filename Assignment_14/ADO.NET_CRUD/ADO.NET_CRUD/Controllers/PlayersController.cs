using ADO.NET_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO.NET_CRUD.Controllers
{
    public class PlayersController : Controller
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        string conString = ConfigurationManager.ConnectionStrings["PlayersConStr"].ConnectionString;
        // GET: Players
        public ActionResult Index()
        {
            List<Player> players = new List<Player>();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Player", con);
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    players.Add(new Player
                    {
                        PlayerId = (int)reader["PlayerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        JerseyNumber = (int)reader["JerseyNumber"],
                        Position = (string)reader["Position"],
                        Team = (string)reader["Team"]
                    });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }
            return View(players);
        }

        // GET: Players/Details/5
        public ActionResult Details(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Player", con);
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    player = (new Player
                    {
                        PlayerId = (int)reader["PlayerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        JerseyNumber = (int)reader["JerseyNumber"],
                        Position = (string)reader["Position"],
                        Team = (string)reader["Team"]
                    });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("insert into Player values (@id, @fn, @ln, @jn, @pos, @team)", con);

                cmd.Parameters.AddWithValue("@id", player.PlayerId);
                cmd.Parameters.AddWithValue("@fn", player.FirstName);
                cmd.Parameters.AddWithValue("@ln", player.LastName);
                cmd.Parameters.AddWithValue("@jn", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@pos", player.Position);
                cmd.Parameters.AddWithValue("@team", player.Team);

                con.Open();
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");

            }
            finally
            {
                con.Close();
            }
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int id)
        {
           Player player = new Player();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Player where PlayerId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    player = (new Player
                    {
                        PlayerId = (int)reader["PlayerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        JerseyNumber = (int)reader["JerseyNumber"],
                        Position = (string)reader["Position"],
                        Team = (string)reader["Team"]
                    });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Player player)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("update Player set FirstName = @fn, LastName = @ln, JerseyNumber = @jn, Position = @pos, Team = @team where PlayerId = @pid", con);

                cmd.Parameters.AddWithValue("@pid", player.PlayerId);
                cmd.Parameters.AddWithValue("@fn", player.FirstName);
                cmd.Parameters.AddWithValue("@ln", player.LastName);
                cmd.Parameters.AddWithValue("@jn", player.JerseyNumber);
                cmd.Parameters.AddWithValue("@pos", player.Position);
                cmd.Parameters.AddWithValue("@team", player.Team);

                con.Open();
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");

            }
            finally
            {
                con.Close();
            }
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int id)
        {
            Player player = new Player();
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Player where PlayerId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    player = (new Player
                    {
                        PlayerId = (int)reader["PlayerId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        JerseyNumber = (int)reader["JerseyNumber"],
                        Position = (string)reader["Position"],
                        Team = (string)reader["Team"]
                    });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");
            }
            finally
            {
                con.Close();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Player player)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("delete from Player where PlayerId = @id", con);

                cmd.Parameters.AddWithValue("@id", player.PlayerId);

                con.Open();
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Error");

            }
            finally
            {
                con.Close();
            }
        }
    }
}

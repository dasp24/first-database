using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAndModel.Models;
using System.Data.SqlClient;



namespace UserAndModel.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con;
        SqlCommand cmd;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult newEntry()
        {
            return View();
        }

        public void connectToServer()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=c:\\users\\admin\\source\\repos\\first-database\\UserAndModel\\UserAndModel\\App_Data\\Database1.mdf;Integrated Security=True";
            con.Open();
            cmd = con.CreateCommand();
        }

        public ActionResult Add(SexyModel x)
        {

            connectToServer();
            cmd.CommandText = $"insert into people values('{x.name}','{x.Address}','{x.number}')";
            cmd.ExecuteNonQuery();
            return View("Index");
            
        }
        public ActionResult Update(SexyModel x,int cin)
        {
            connectToServer();
            cmd.CommandText = $"UPDATE people SET Name = '{x.name}',address = '{x.Address}',telephone ='{x.number}' where CIN = {cin}";
            cmd.ExecuteNonQuery();
            return View("Index");

        }

        public ActionResult Edit(SexyModel x, int cin)
        {
            ViewData["update"] = ""+cin;
            return View("newEntry");

        }

        public ActionResult Delete(SexyModel x, int cin)
        {

            connectToServer();
            cmd.CommandText = $"DELETE FROM people WHERE CIN = {cin}";
            cmd.ExecuteNonQuery();
            con.Close();
            return View("Index");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ContosoClinic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
           /* SqlConnection con = new SqlConnection(connection);*/
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select @@version",con);
                var rd = cmd.ExecuteScalar();
                ViewBag.SQLServerVersion = rd;
                cmd = new SqlCommand("Exec GetEngineEdition", con);
                rd = cmd.ExecuteScalar();
                ViewBag.SQLEngineEdition = rd;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }
    }
}
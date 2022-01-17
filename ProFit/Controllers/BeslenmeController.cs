using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class BeslenmeController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        // GET: Beslenme
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FitYemek()
        {
            string query = "Select * from foods  Order By food_ID DESC";
            baglanti.Open();
            var foods = new List<foods>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                foods.Add(new foods()
                {
                    food_ID = Convert.ToInt32(rd["food_ID"]),
                    food_NAME = (rd["food_NAME"]).ToString(),
                    food_CONTENT = (rd["food_CONTENT"]).ToString(),
                    food_IMAGE = (rd["food_IMAGE"]).ToString(),
                    food_RECIPE = (rd["food_RECIPE"]).ToString(),


                });
            }
            rd.Close();
            baglanti.Close();
            return View(foods);
        }
        public ActionResult DiyetProgramlari()
        {
            string query = "Select * from diet  Order By diet_ID DESC";
            baglanti.Open();
            var diyetler = new List<diet>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                diyetler.Add(new diet()
                {
                    diet_ID = Convert.ToInt32(rd["diet_ID"]),
                    diet_NAME = (rd["diet_NAME"]).ToString(),
                    diet_DESCRIPTION = (rd["diet_DESCRIPTION"]).ToString(),
                    diet_IMAGE = (rd["diet_IMAGE"]).ToString(),
                    diet_INFO = (rd["diet_INFO"]).ToString(),


                });
            }
            rd.Close();
            baglanti.Close();
            return View(diyetler);
        }
        public ActionResult DahaFazlaDiyet()
        {
            int dietid = Convert.ToInt32(Request.QueryString.Get("id"));

            string query = "Select * from diet where diet_ID="+dietid;
            baglanti.Open();
            var diyetler = new List<diet>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                diyetler.Add(new diet()
                {
                    diet_ID = Convert.ToInt32(rd["diet_ID"]),
                    diet_NAME = (rd["diet_NAME"]).ToString(),
                    diet_DESCRIPTION = (rd["diet_DESCRIPTION"]).ToString(),
                    diet_IMAGE = (rd["diet_IMAGE"]).ToString(),
                    diet_INFO = (rd["diet_INFO"]).ToString(),


                });
            }
            rd.Close();
            baglanti.Close();
            return View(diyetler);
        }

        public ActionResult DahaFazla()
        {
            int foodid = Convert.ToInt32(Request.QueryString.Get("id"));

            string query = "Select * from foods where food_ID="+foodid;
            baglanti.Open();
            var foods = new List<foods>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                foods.Add(new foods()
                {
                    food_ID = Convert.ToInt32(rd["food_ID"]),
                    food_NAME = (rd["food_NAME"]).ToString(),
                    food_CONTENT = (rd["food_CONTENT"]).ToString(),
                    food_IMAGE = (rd["food_IMAGE"]).ToString(),
                    food_RECIPE = (rd["food_RECIPE"]).ToString(),


                });
            }
            rd.Close();
            baglanti.Close();
            return View(foods);
        }
    }
}
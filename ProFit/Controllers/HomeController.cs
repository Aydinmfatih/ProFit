using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class HomeController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        // GET: Home
        public List<foods> Foods()
        {

            string query = "Select * from foods  Order By food_ID DESC";
            baglanti.Open();
            var yemekler = new List<foods>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                yemekler.Add(new foods()
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
            return yemekler;
        }
        public List<site_settings> Sites()
        {
            string query = "Select * from site_settings";
            baglanti.Open();
            var site_Settings = new List<site_settings>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                site_Settings.Add(new site_settings()
                {
                    site_settings_ID = Convert.ToInt32(rd["site_settings_ID"]),
                    site_settings_LOGO = (rd["site_settings_LOGO"]).ToString(),
                    site_settings_PHONE = (rd["site_settings_PHONE"]).ToString(),
                    site_settings_MAIL = (rd["site_settings_MAIL"]).ToString(),
                    site_settings_INSTAGRAM = (rd["site_settings_INSTAGRAM"]).ToString(),
                    site_settings_TWITTER = (rd["site_settings_TWITTER"]).ToString(),
                    site_settings_YOUTUBE = (rd["site_settings_YOUTUBE"]).ToString()

                });
            }
            rd.Close();
            baglanti.Close();
            return site_Settings;
        }
        public ActionResult Index()
        {
            ModelView modelView = new ModelView();
            modelView.Foods = Foods();
            modelView.Site_Settings = Sites();

            return View(modelView);
        }
    }
}
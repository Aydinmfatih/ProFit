using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class HeaderController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        // GET: Header
        public ActionResult _Header()
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
            return PartialView(site_Settings);
        }
    }
}
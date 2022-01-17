using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class AdminSiteAyarlariController : Controller
    {
        // GET: AdminSiteAyarları
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        // GET: AdminSiteAyarları
        public ActionResult Index()
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
            return View(site_Settings);
        }
        [HttpGet]
        public ActionResult SiteGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SiteGuncelle(site_settings sitesettings, HttpPostedFileBase file)
        {
            string ResimAdi = System.IO.Path.GetFileName(file.FileName);
            string adres = Server.MapPath("~/images/" + ResimAdi);
            file.SaveAs(adres);
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Update site_settings set site_settings_LOGO='" + ResimAdi + "' , site_settings_PHONE='" + sitesettings.site_settings_PHONE + "'" +
                " , site_settings_MAIL='" + sitesettings.site_settings_MAIL + "',site_settings_INSTAGRAM='" + sitesettings.site_settings_INSTAGRAM + "'" +
                ",site_settings_TWITTER='" + sitesettings.site_settings_TWITTER + "',site_settings_YOUTUBE='" + sitesettings.site_settings_YOUTUBE + "' where site_settings_ID=" + sitesettings.site_settings_ID + "", baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                sitesettings.site_settings_LOGO = (rd["site_settings_LOGO"]).ToString();
                sitesettings.site_settings_PHONE = (rd["site_settings_PHONE"]).ToString();
                sitesettings.site_settings_MAIL = (rd["site_settings_MAIL"]).ToString();
                sitesettings.site_settings_INSTAGRAM = (rd["site_settings_INSTAGRAM"]).ToString();
                sitesettings.site_settings_TWITTER = (rd["site_settings_TWITTER"]).ToString();
                sitesettings.site_settings_YOUTUBE = (rd["site_settings_YOUTUBE"]).ToString();
            }
            baglanti.Close();
            return RedirectToAction("Index", "AdminSiteAyarlari");

        }
        public ActionResult SiteAyarlariEdit(site_settings sitesettings)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from site_settings where site_settings_ID=" + sitesettings.site_settings_ID + "", baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                sitesettings.site_settings_LOGO = (rd["site_settings_LOGO"]).ToString();
                sitesettings.site_settings_PHONE = (rd["site_settings_PHONE"]).ToString();
                sitesettings.site_settings_MAIL = (rd["site_settings_MAIL"]).ToString();
                sitesettings.site_settings_INSTAGRAM = (rd["site_settings_INSTAGRAM"]).ToString();
                sitesettings.site_settings_TWITTER = (rd["site_settings_TWITTER"]).ToString();
                sitesettings.site_settings_YOUTUBE = (rd["site_settings_YOUTUBE"]).ToString();

            }
            baglanti.Close();
            return View("SiteGuncelle", sitesettings);
        }
    }
}
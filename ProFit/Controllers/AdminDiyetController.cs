using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class AdminDiyetController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

       
        public ActionResult Index()
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
        [HttpGet]
        public ActionResult DiyetKaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DiyetKaydet(diet diyetler, HttpPostedFileBase file)
        {
            string ResimAdi = System.IO.Path.GetFileName(file.FileName);
            string adres = Server.MapPath("~/images/" + ResimAdi);
            file.SaveAs(adres);

            if (diyetler.diet_ID == 0)
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into diet (diet_ID ,diet_NAME,diet_DESCRIPTION,diet_IMAGE,diet_INFO" +
                    ")values (Null," +
                                                    "'" + diyetler.diet_NAME + "','" + diyetler.diet_DESCRIPTION + "','" + ResimAdi + "'," +
                                                    "'" + diyetler.diet_INFO + "')", baglanti);

                cmd.ExecuteNonQuery();
                baglanti.Close();
                return RedirectToAction("Index", "AdminDiyet");
            }
            else
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Update diet set diet_NAME='" + diyetler.diet_NAME + "', diet_DESCRIPTION='" + diyetler.diet_DESCRIPTION + "'," +
                    " diet_IMAGE='" + ResimAdi + "', diet_INFO='" + diyetler.diet_INFO + "'"  +                   
                    " where diet_ID =" + diyetler.diet_ID + "", baglanti);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    diyetler.diet_NAME = (rd["diet_NAME"]).ToString();
                    diyetler.diet_DESCRIPTION = (rd["diet_DESCRIPTION"]).ToString();
                    diyetler.diet_IMAGE = (rd["diet_IMAGE"]).ToString();
                    diyetler.diet_INFO = (rd["diet_INFO"]).ToString();
                    
                }
                baglanti.Close();
            }
            return RedirectToAction("Index", "AdminDiyet");
        }
        public ActionResult DietEdit(diet diyetler)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from diet where diet_ID=" + diyetler.diet_ID+ "", baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                diyetler.diet_NAME = (rd["diet_NAME"]).ToString();
                diyetler.diet_DESCRIPTION = (rd["diet_DESCRIPTION"]).ToString();
                diyetler.diet_IMAGE = (rd["diet_IMAGE"]).ToString();
                diyetler.diet_INFO = (rd["diet_INFO"]).ToString();
            }
            baglanti.Close();
            return View("DiyetKaydet", diyetler);
        }
        public ActionResult DietDelete(diet diyetler)
        {
            string query = "Delete from diet where diet_ID=" + diyetler.diet_ID + "";
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            return RedirectToAction("Index", "AdminDiyet");
        }
    }
}
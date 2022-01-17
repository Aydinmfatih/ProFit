using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class AdminYemekController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);


        public ActionResult Index()
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
            return View(yemekler);
        }
        [HttpGet]
        public ActionResult YemekKaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YemekKaydet(foods yemekler, HttpPostedFileBase file)
        {
            string ResimAdi = System.IO.Path.GetFileName(file.FileName);
            string adres = Server.MapPath("~/images/" + ResimAdi);
            file.SaveAs(adres);

            if (yemekler.food_ID == 0)
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into foods (food_ID ,food_NAME,food_CONTENT,food_IMAGE,food_RECIPE" +
                    ")values (Null," +
                                                   "'" + yemekler.food_NAME + "','" + yemekler.food_CONTENT + "','" + ResimAdi + "'," +
                                                    "'" + yemekler.food_RECIPE + "')", baglanti);

                cmd.ExecuteNonQuery();
                baglanti.Close();
                return RedirectToAction("Index", "AdminYemek");
            }
            else
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Update foods set food_NAME='" + yemekler.food_NAME + "', food_CONTENT='" + yemekler.food_CONTENT + "'," +
                    " food_IMAGE='" + ResimAdi + "', food_RECIPE='" + yemekler.food_RECIPE + "'" +
                    " where food_ID =" + yemekler.food_ID + "", baglanti);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    yemekler.food_ID = Convert.ToInt32(rd["food_ID"]);
                    yemekler.food_NAME = (rd["food_NAME"]).ToString();
                    yemekler.food_CONTENT = (rd["food_CONTENT"]).ToString();
                    yemekler.food_IMAGE = (rd["food_IMAGE"]).ToString();
                    yemekler.food_RECIPE = (rd["food_RECIPE"]).ToString();


                }
                baglanti.Close();
            }
            return RedirectToAction("Index", "AdminYemek");
        }
        public ActionResult FoodEdit(foods yemekler)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from foods where food_ID=" + yemekler.food_ID + "", baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                yemekler.food_ID = Convert.ToInt32(rd["food_ID"]);
                yemekler.food_NAME = (rd["food_NAME"]).ToString();
                yemekler.food_CONTENT = (rd["food_CONTENT"]).ToString();
                yemekler.food_IMAGE = (rd["food_IMAGE"]).ToString();
                yemekler.food_RECIPE = (rd["food_RECIPE"]).ToString();

            }
            baglanti.Close();
            return View("YemekKaydet", yemekler);
        }
        public ActionResult FoodDelete(foods yemekler)
        {
            string query = "Delete from foods where food_ID=" + yemekler.food_ID + "";
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            return RedirectToAction("Index", "AdminYemek");
        }
    }
}
using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class AdminProgramController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);


        public ActionResult Index()
        {
            string query = "Select training_program.training_ID,training_program.category_NAME,training_program.training_NAME,training_program.training_DESCRIPTION,training_program.training_IMAGE,training_program.training_INFO,training_program.training_youtube_LINK FROM training_program INNER JOIN categories ON training_program.category_NAME=categories.category_NAME";
            baglanti.Open();
            var programlar = new List<training_program>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                programlar.Add(new training_program()
                {
                    training_ID = Convert.ToInt32(rd["training_ID"]),
                    category_NAME = (rd["category_NAME"]).ToString(),
                    training_NAME = (rd["training_NAME"]).ToString(),
                    training_DESCRIPTION = (rd["training_DESCRIPTION"]).ToString(),
                    training_IMAGE = (rd["training_IMAGE"]).ToString(),
                    training_INFO = (rd["training_INFO"]).ToString(),
                    training_youtube_LINK = (rd["training_youtube_LINK"]).ToString(),


                });
            }
            rd.Close();
            baglanti.Close();
            return View(programlar);
        }
        [HttpGet]
        public ActionResult ProgramKaydet()
        {
            var category = new List<categories>();
            baglanti.Open();
            MySqlCommand cmmd = new MySqlCommand("select * from categories", baglanti);
            MySqlDataReader red = cmmd.ExecuteReader();
            while (red.Read())
            {
                category.Add(new categories()
                {
                    category_ID = Convert.ToInt32(red["category_ID"]),
                    category_NAME = (red["category_NAME"]).ToString(),


                });
            }
            ViewBag.categorys = new SelectList(category, "category_NAME", "category_NAME");
            baglanti.Close();

            return View(Tuple.Create<List<categories>, training_program>(category, new training_program()));
        }
        [HttpPost]
        public ActionResult ProgramKaydet([Bind(Prefix ="item2")] training_program Model2, HttpPostedFileBase file)
        {

            if (Model2.training_ID == 0)
            {
            string ResimAdi = System.IO.Path.GetFileName(file.FileName);
            string adres = Server.MapPath("~/images/" + ResimAdi);
            file.SaveAs(adres);
                string ddlValue = Request.Form["categorys"].ToString();


            
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into training_program (training_ID,category_NAME,training_NAME,training_DESCRIPTION,training_IMAGE,training_INFO,training_youtube_LINK" +
                    ")values (Null," +
                                                   "'" + ddlValue + "','" + Model2.training_NAME + "','" + Model2.training_DESCRIPTION + "','" + ResimAdi + "'," +
                                                    "'" + Model2.training_INFO + "','" + Model2.training_youtube_LINK + "')", baglanti);

                cmd.ExecuteNonQuery();
                baglanti.Close();
                return RedirectToAction("Index", "AdminProgram");
            }
            else
            {

                string ResimAdi = System.IO.Path.GetFileName(file.FileName);
                string adres = Server.MapPath("~/images/" + ResimAdi);
                string ddlValue = Request.Form["categorys"].ToString();
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Update training_program set category_NAME='" +ddlValue + "', training_NAME='" + Model2.training_NAME + "'," +
                    " training_DESCRIPTION='" + Model2.training_DESCRIPTION  +"', training_IMAGE='" + ResimAdi + "', training_INFO='" + Model2.training_INFO + "'" +
                        ", training_youtube_LINK='" + Model2.training_youtube_LINK + "' where training_ID =" + Model2.training_ID + "", baglanti);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Model2.training_ID = Convert.ToInt32(rd["training_ID "]);
                    Model2.category_NAME = (rd["category_NAME"]).ToString();
                    Model2.training_NAME = (rd["training_NAME"]).ToString();
                    Model2.training_DESCRIPTION = (rd["training_DESCRIPTION"]).ToString();
                    Model2.training_IMAGE = (rd["training_IMAGE"]).ToString();
                    Model2.training_INFO = (rd["training_INFO"]).ToString();
                    Model2.training_youtube_LINK = (rd["training_youtube_LINK"]).ToString();


                }
                baglanti.Close();
            }
            return RedirectToAction("Index", "AdminProgram");
        }
        public ActionResult ProgramEdit(training_program programlar)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from training_program where training_ID=" + programlar.training_ID + "", baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                programlar.training_ID = Convert.ToInt32(rd["training_ID"]);
                programlar.category_NAME = (rd["category_NAME"]).ToString();
                programlar.training_NAME = (rd["training_NAME"]).ToString();
                programlar.training_DESCRIPTION = (rd["training_DESCRIPTION"]).ToString();
                programlar.training_IMAGE = (rd["training_IMAGE"]).ToString();
                programlar.training_INFO = (rd["training_INFO"]).ToString();
                programlar.training_youtube_LINK = (rd["training_youtube_LINK"]).ToString();

            }
            rd.Close();
            var category = new List<categories>();
            MySqlCommand cmmd = new MySqlCommand("select * from categories", baglanti);
            MySqlDataReader red = cmmd.ExecuteReader();
            while (red.Read())
            {
                category.Add(new categories()
                {
                    category_ID = Convert.ToInt32(red["category_ID"]),
                    category_NAME = (red["category_NAME"]).ToString(),


                });
            }
            red.Close();
            baglanti.Close();
            ViewBag.categorys = new SelectList(category, "category_NAME", "category_NAME");
            return View("ProgramKaydet", Tuple.Create<List<categories>,training_program>(category,programlar));
        }
        public ActionResult ProgramDelete(training_program programlar)
        {
            string query = "Delete from training_program where training_ID=" +programlar.training_ID + "";
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            return RedirectToAction("Index", "AdminProgram");
        }
    }
}
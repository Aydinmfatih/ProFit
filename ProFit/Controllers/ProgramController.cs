using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class ProgramController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        // GET: Program
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FitnessBaslangicSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='Başlangıç Seviye Fitness Antreman Programı'";
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
        public ActionResult FitnessOrtaSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='Orta Seviye Fitness Antreman Programı'";
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
        public ActionResult FitnessIleriSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='İleri Seviye Fitness Antreman Programı'";
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
        public ActionResult YogaBaslangicSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='Başlangıç Seviye Yoga Antreman Programı'";
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
        public ActionResult YogaOrtaSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='Orta Seviye Yoga Antreman Programı'";
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
        public ActionResult YogaIleriSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='İleri Seviye Yoga Antreman Programı'";
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
        public ActionResult PilatesBaslangicSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='Başlangıç Seviye Pilates Antreman Programı'";
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
        public ActionResult PilatesOrtaSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='Orta Seviye Pilates Antreman Programı'";
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
        public ActionResult PilatesIleriSeviyesi()
        {
            string query = "Select * from training_program where category_NAME='İleri Seviye Pilates Antreman Programı'";
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
        public ActionResult DahaFazla(int id)
        {
            string query = "Select * from training_program where training_ID="+id+"";
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
    }
}
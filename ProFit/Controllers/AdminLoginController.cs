using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProFit.Controllers
{
    public class AdminLoginController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();

        }
        private string Passget(string k_adi)
        {
            string query = "Select login_PASSWORD from login where login_NAME='" + k_adi + "'";
            baglanti.Open();
            var sifre = new List<string>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                sifre.Add(rd["login_PASSWORD"].ToString());


            }
            rd.Close();
            baglanti.Close();
            return sifre.Last().ToString();
        }
        [HttpPost]
        public ActionResult Index(login Login, string password)
        {
            var pass = Passget(Login.login_NAME);
            string has = DecodeFrom64(pass);
            string hashpass;
            if (password == has)
                hashpass = pass;
            else
                return RedirectToAction("Index", "Login");
            baglanti.Open();
            string query1 = "Select login_NAME,login_PASSWORD from login where login_NAME='" + Login.login_NAME + "' and login_PASSWORD='" + pass + "'";
            MySqlCommand cmmd = new MySqlCommand(query1, baglanti);
            MySqlDataReader red = cmmd.ExecuteReader();
            if (red.Read())
            {
                FormsAuthentication.SetAuthCookie(query1, false);
                return RedirectToAction("Index", "AdminHome");
            }

            else
            {
                return View();
            }
        }
        private string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
             = Encoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = Convert.FromBase64String(encodedData);
            string returnValue =
               Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
        [HttpGet]
        public ActionResult SifreDegistirme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifreDegistirme(login Login)
        {
            string password = EncodeTo64(Login.login_PASSWORD);
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Update login set login_NAME = '" + Login.login_NAME+ "', login_PASSWORD = '" + password + "'"
                    + " where login_NAME='" + Login.login_NAME + "'", baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}
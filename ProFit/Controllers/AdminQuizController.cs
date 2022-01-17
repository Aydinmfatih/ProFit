using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class AdminQuizController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        // GET: AdminQuiz
        public ActionResult Index()
        {
            string query = "Select * from quiz_question  Order By quiz_question_ID DESC";
            baglanti.Open();
            var quizler = new List<quiz_question>();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                quizler.Add(new quiz_question()
                {
                    quiz_question_ID = Convert.ToInt32(rd["quiz_question_ID"]),
                    quiz_question_NAME = (rd["quiz_question_NAME"]).ToString(),
                    quiz_QUESTION1 = (rd["quiz_QUESTION1"]).ToString(),
                    quiz_QUESTION2 = (rd["quiz_QUESTION2"]).ToString(),
                    quiz_QUESTION3 = (rd["quiz_QUESTION3"]).ToString(),
                    quiz_QUESTION4 = (rd["quiz_QUESTION4"]).ToString(),
                    quiz_QUESTION5 = (rd["quiz_QUESTION5"]).ToString(),
                    quiz_QUESTION6 = (rd["quiz_QUESTION6"]).ToString(),
                    quiz_QUESTION7 = (rd["quiz_QUESTION7"]).ToString(),
                    quiz_QUESTION8 = (rd["quiz_QUESTION8"]).ToString(),
                    quiz_QUESTION9 = (rd["quiz_QUESTION9"]).ToString(),
                    quiz_QUESTION10 = (rd["quiz_QUESTION10"]).ToString()

                });
            }
            rd.Close();
            baglanti.Close();
            return View(quizler);
        }
        [HttpGet]
        public ActionResult QuizKaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuizKaydet(quiz_question quizler)
        {

            if (quizler.quiz_question_ID == 0)
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into quiz_question (quiz_question_ID ,quiz_question_NAME,quiz_QUESTION1,quiz_QUESTION2,quiz_QUESTION3,quiz_QUESTION4" +
                    ",quiz_QUESTION5,quiz_QUESTION6,quiz_QUESTION7,quiz_QUESTION8,quiz_QUESTION9,quiz_QUESTION10)values (Null," +
                                                    "'" + quizler.quiz_question_NAME + "','" + quizler.quiz_QUESTION1 + "','" + quizler.quiz_QUESTION2 + "'," +
                                                    "'" + quizler.quiz_QUESTION3 + "','" + quizler.quiz_QUESTION4 + "','" + quizler.quiz_QUESTION5 + "','" + quizler.quiz_QUESTION6 + "'" +
                                                    ",'" + quizler.quiz_QUESTION7 + "','" + quizler.quiz_QUESTION8 + "','" + quizler.quiz_QUESTION9 + "','" + quizler.quiz_QUESTION10 + "')", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                return RedirectToAction("Index", "AdminQuiz");
            }
            else
            {
                baglanti.Open();
                MySqlCommand cmd = new MySqlCommand("Update quiz_question set quiz_question_NAME='" + quizler.quiz_question_NAME + "', quiz_QUESTION1='" + quizler.quiz_QUESTION1 + "'," +
                    " quiz_QUESTION2='" + quizler.quiz_QUESTION2 + "', quiz_QUESTION3='" + quizler.quiz_QUESTION3 + "' , quiz_QUESTION4='" + quizler.quiz_QUESTION4 + "'" +
                    ", quiz_QUESTION5='" + quizler.quiz_QUESTION5 + "',quiz_QUESTION6='" + quizler.quiz_QUESTION6 + "',quiz_QUESTION7='" + quizler.quiz_QUESTION7 + "'" +
                    ", quiz_QUESTION8='" + quizler.quiz_QUESTION8 + "', quiz_QUESTION9='" + quizler.quiz_QUESTION9 + "', quiz_QUESTION10='" + quizler.quiz_QUESTION10 + "' where quiz_question_ID =" + quizler.quiz_question_ID + "", baglanti);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    quizler.quiz_question_NAME = (rd["quiz_question_NAME"]).ToString();
                    quizler.quiz_QUESTION1 = (rd["quiz_QUESTION1"]).ToString();
                    quizler.quiz_QUESTION2 = (rd["quiz_QUESTION2"]).ToString();
                    quizler.quiz_QUESTION3 = (rd["quiz_QUESTION3"]).ToString();
                    quizler.quiz_QUESTION4 = (rd["quiz_QUESTION4"]).ToString();
                    quizler.quiz_QUESTION5 = (rd["quiz_QUESTION5"]).ToString();
                    quizler.quiz_QUESTION6 = (rd["quiz_QUESTION6"]).ToString();
                    quizler.quiz_QUESTION7 = (rd["quiz_QUESTION7"]).ToString();
                    quizler.quiz_QUESTION8 = (rd["quiz_QUESTION8"]).ToString();
                    quizler.quiz_QUESTION9 = (rd["quiz_QUESTION9"]).ToString();
                    quizler.quiz_QUESTION10 = (rd["quiz_QUESTION10"]).ToString();
                }
                baglanti.Close();
            }
            return RedirectToAction("Index", "AdminQuiz");
        }
        public ActionResult QuizEdit(quiz_question quizler)
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from quiz_question where quiz_question_ID=" + quizler.quiz_question_ID + "", baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                quizler.quiz_question_NAME = (rd["quiz_question_name"]).ToString();
                quizler.quiz_QUESTION1 = (rd["quiz_QUESTION1"]).ToString();
                quizler.quiz_QUESTION2 = (rd["quiz_QUESTION2"]).ToString();
                quizler.quiz_QUESTION3 = (rd["quiz_QUESTION3"]).ToString();
                quizler.quiz_QUESTION4 = (rd["quiz_QUESTION4"]).ToString();
                quizler.quiz_QUESTION5 = (rd["quiz_QUESTION5"]).ToString();
                quizler.quiz_QUESTION6 = (rd["quiz_QUESTION6"]).ToString();
                quizler.quiz_QUESTION7 = (rd["quiz_QUESTION7"]).ToString();
                quizler.quiz_QUESTION8 = (rd["quiz_QUESTION8"]).ToString();
                quizler.quiz_QUESTION9 = (rd["quiz_QUESTION9"]).ToString();
                quizler.quiz_QUESTION10 = (rd["quiz_QUESTION10"]).ToString();
            }
            baglanti.Close();
            return View("QuizKaydet", quizler);
        }
        public ActionResult QuizDelete(quiz_question quizler)
        {
            string query = "Delete from quiz_question where quiz_question_ID=" + quizler.quiz_question_ID + "";
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            return RedirectToAction("Index", "AdminQuiz");
        }
    }
}
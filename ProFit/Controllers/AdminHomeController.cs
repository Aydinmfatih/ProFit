using MySql.Data.MySqlClient;
using ProFit.Models.pro_fitdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProFit.Controllers
{
    public class AdminHomeController : Controller
    {
        MySqlConnection baglanti = new MySqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["bcum"].ConnectionString);

        public List<quiz_answer> Quiz_Answers()
        {
            string query = "Select * from quiz_answer";
            var answers = new List<quiz_answer>();
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                answers.Add(new quiz_answer()
                {
                    quiz_answer_ID = Convert.ToInt32(rd["quiz_answer_ID"]),
                    quiz_question_ID = Convert.ToInt32(rd["quiz_question_ID"]),
                    quiz_answer_MAIL = (rd["quiz_answer_MAIL"]).ToString(),
                    quiz_ANSWER1 = (rd["quiz_ANSWER1"]).ToString(),
                    quiz_ANSWER2 = (rd["quiz_ANSWER2"]).ToString(),
                    quiz_ANSWER3 = (rd["quiz_ANSWER3"]).ToString(),
                    quiz_ANSWER4 = (rd["quiz_ANSWER4"]).ToString(),
                    quiz_ANSWER5 = (rd["quiz_ANSWER5"]).ToString(),
                    quiz_ANSWER6 = (rd["quiz_ANSWER6"]).ToString(),
                    quiz_ANSWER7 = (rd["quiz_ANSWER7"]).ToString(),
                    quiz_ANSWER8 = (rd["quiz_ANSWER8"]).ToString(),
                    quiz_ANSWER9 = (rd["quiz_ANSWER9"]).ToString(),
                    quiz_ANSWER10 = (rd["quiz_ANSWER10"]).ToString(),
                    quiz_answer_DATE =Convert.ToDateTime(rd["quiz_answer_DATE"])
                });
            }
            rd.Close();
            baglanti.Close();
            return answers;
        }
        public List<request_complaint> Request_Complaints()
        {
            string query = "Select * from request_complaint  Order By request_complaint_ID DESC";
            var request = new List<request_complaint>();
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                request.Add(new request_complaint()
                {
                    request_complaint_ID = Convert.ToInt32(rd["request_complaint_ID"]),
                    request_complaint_MAIL = (rd["request_complaint_MAIL"]).ToString(),
                    request_complaint_DESCRIPTION = (rd["request_complaint_DESCRIPTION"]).ToString(),
                    request_complaint_DATE = Convert.ToDateTime(rd["request_complaint_DATE"])
                });
            }
            rd.Close();
            baglanti.Close();
            return request;
        }
        // GET: AdminHome
        public ActionResult Index()
        {
            ModelView modelView= new ModelView();
            modelView.quiz_Answers=Quiz_Answers();
            modelView.request_Complaints=Request_Complaints();
            return View(modelView);
        }
        public ActionResult Detay()
        {
            int quizid = Convert.ToInt32(Request.QueryString.Get("id"));

            string query = "Select * from quiz_answer where quiz_answer_ID=" + quizid;
            var answers = new List<quiz_answer>();
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand(query, baglanti);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                answers.Add(new quiz_answer()
                {
                    quiz_answer_ID = Convert.ToInt32(rd["quiz_answer_ID"]),
                    quiz_question_ID = Convert.ToInt32(rd["quiz_question_ID"]),
                    quiz_answer_MAIL = (rd["quiz_answer_MAIL"]).ToString(),
                    quiz_ANSWER1 = (rd["quiz_ANSWER1"]).ToString(),
                    quiz_ANSWER2 = (rd["quiz_ANSWER2"]).ToString(),
                    quiz_ANSWER3 = (rd["quiz_ANSWER3"]).ToString(),
                    quiz_ANSWER4 = (rd["quiz_ANSWER4"]).ToString(),
                    quiz_ANSWER5 = (rd["quiz_ANSWER5"]).ToString(),
                    quiz_ANSWER6 = (rd["quiz_ANSWER6"]).ToString(),
                    quiz_ANSWER7 = (rd["quiz_ANSWER7"]).ToString(),
                    quiz_ANSWER8 = (rd["quiz_ANSWER8"]).ToString(),
                    quiz_ANSWER9 = (rd["quiz_ANSWER9"]).ToString(),
                    quiz_ANSWER10 = (rd["quiz_ANSWER10"]).ToString(),
                    quiz_answer_DATE = Convert.ToDateTime(rd["quiz_answer_DATE"])
                });
            }
            rd.Close();
            baglanti.Close();
            return View(answers);
        }
    }
}
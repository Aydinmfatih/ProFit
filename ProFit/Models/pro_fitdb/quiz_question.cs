using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class quiz_question
    {
        public int quiz_question_ID { get; set; }
        [DisplayName("Quiz Adı")]
        public string quiz_question_NAME { get; set; }
        [DisplayName("Soru 1")]
        public string quiz_QUESTION1 { get; set; }
        [DisplayName("Soru 2")]
        public string quiz_QUESTION2 { get; set; }
        [DisplayName("Soru 3")]
        public string quiz_QUESTION3 { get; set; }
        [DisplayName("Soru 4")]
        public string quiz_QUESTION4 { get; set; }
        [DisplayName("Soru 5")]
        public string quiz_QUESTION5 { get; set; }
        [DisplayName("Soru 6")]
        public string quiz_QUESTION6 { get; set; }
        [DisplayName("Soru 7")]
        public string quiz_QUESTION7 { get; set; }
        [DisplayName("Soru 8")]
        public string quiz_QUESTION8 { get; set; }
        [DisplayName("Soru 9")]
        public string quiz_QUESTION9 { get; set; }
        [DisplayName("Soru 10")]
        public string quiz_QUESTION10 { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class quiz_answer
    {
        public int quiz_answer_ID { get; set; }
        public int quiz_question_ID { get; set; }
        public string quiz_answer_MAIL { get; set; }

        public string quiz_ANSWER1 { get; set; }
        public string quiz_ANSWER2 { get; set; }
        public string quiz_ANSWER3 { get; set; }
        public string quiz_ANSWER4 { get; set; }
        public string quiz_ANSWER5 { get; set; }
        public string quiz_ANSWER6 { get; set; }
        public string quiz_ANSWER7 { get; set; }
        public string quiz_ANSWER8 { get; set; }
        public string quiz_ANSWER9 { get; set; }
        public string quiz_ANSWER10 { get; set; }
        public DateTime quiz_answer_DATE { get; set; }
    }
}
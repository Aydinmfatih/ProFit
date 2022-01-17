using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class ModelView
    {
        public IEnumerable<quiz_answer> quiz_Answers { get; set; }
        public IEnumerable<request_complaint> request_Complaints { get; set; }
        public IEnumerable<foods> Foods { get; set; }
        public IEnumerable<site_settings> Site_Settings { get; set; }
    }
}
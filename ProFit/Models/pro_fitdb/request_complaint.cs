using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class request_complaint
    {
        public int request_complaint_ID { get; set; }
        public string request_complaint_MAIL { get; set; }
        public string request_complaint_DESCRIPTION { get; set; }
        public DateTime request_complaint_DATE { get; set; }
    }
}
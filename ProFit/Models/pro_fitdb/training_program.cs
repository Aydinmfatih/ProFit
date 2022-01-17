using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class training_program
    {
        public int training_ID { get; set; }
        public string category_NAME { get; set; }
        public string training_NAME { get; set; }
        public string training_DESCRIPTION { get; set; }
        public string training_IMAGE { get; set; }
        public string training_INFO { get; set; }
        public string training_youtube_LINK{ get; set; }
        
    }
}
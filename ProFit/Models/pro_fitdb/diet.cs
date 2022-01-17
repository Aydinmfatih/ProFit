using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class diet
    {
        public int diet_ID { get; set; }
        [DisplayName("Diyet Adı")]
        public string diet_NAME { get; set; }
        [DisplayName("Diyet Açıklaması")]
        public string diet_DESCRIPTION { get; set; }
        [DisplayName("Diyet Resmi")]

        public string diet_IMAGE { get; set; }
        [DisplayName("Diyet Bilgi")]
        public string diet_INFO { get; set; }
       
    }
}
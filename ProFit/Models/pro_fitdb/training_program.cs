using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class training_program
    {
        public int training_ID { get; set; }
        [DisplayName("Kategori Adı")]
        public string category_NAME { get; set; }
        [DisplayName("Program Adı")]
        public string training_NAME { get; set; }
        [DisplayName("Program Açıklaması")]
        public string training_DESCRIPTION { get; set; }
        [DisplayName("Program Resim")]

        public string training_IMAGE { get; set; }
        [DisplayName("Program Bilgisi")]
        public string training_INFO { get; set; }
        [DisplayName("Youtube Linki")]
        public string training_youtube_LINK{ get; set; }
        
    }
}
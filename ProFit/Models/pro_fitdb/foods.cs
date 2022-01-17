using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class foods
    {
        
        public int food_ID { get; set; }
        [DisplayName("Yemek Adı")]
        public string food_NAME { get; set; }
        [DisplayName("Yemek İçeriği")]
        public string food_CONTENT { get; set; }
        [DisplayName("Yemek Resmi")]
        public string food_IMAGE { get; set; }
        [DisplayName("Yemek Tarifi")]
        public string food_RECIPE { get; set; }
    }
}
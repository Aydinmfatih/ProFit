using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProFit.Models.pro_fitdb
{
    public class login
    {
       
        public int login_ID { get; set; }
        public string login_NAME { get; set; }
        [DataType(DataType.Password)]
        public string login_PASSWORD { get; set; }
    }
}
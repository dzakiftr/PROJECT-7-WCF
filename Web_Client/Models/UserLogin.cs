using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web_Client.Models
{
    public class UserLogin
    {
        [DisplayName("Insert Username")]
        public string id { get; set; }
       
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
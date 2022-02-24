using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Online_Rental_System_BE.Models
{
    public class Response
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public RegisterUser registerUser { get; set; }
        public DataTable lstRegisterUser { get; set; }
        public Product product { get; set; }
        public DataTable lstProducts { get; set; }
    }
    public class RegistrationResponse
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
    }
}
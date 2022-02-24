using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Rental_System_BE.Models
{
    public class RegisterUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
       
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Type { get; set; } = string.Empty;

    }
}
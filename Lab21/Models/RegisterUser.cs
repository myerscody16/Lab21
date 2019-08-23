using System;
using System.Collections.Generic;

namespace Lab21.Models
{
    public partial class RegisterUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FavoriteColor { get; set; }
    }
}

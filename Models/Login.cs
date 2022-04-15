using System;
using System.Collections.Generic;

#nullable disable

namespace curdoperation.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginId { get; set; }
    }
}

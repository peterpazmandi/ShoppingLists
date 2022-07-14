using System;
using System.Collections.Generic;
using System.Text;

namespace APIRequests.Models
{
    public class User : DomainObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}

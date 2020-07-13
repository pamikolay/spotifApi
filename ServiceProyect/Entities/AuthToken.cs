using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceProyect.Entities
{
    public class AuthToken
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
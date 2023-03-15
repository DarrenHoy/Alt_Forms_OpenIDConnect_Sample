using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Alt_Forms_OpenIDConnect_Sample
{
    public class AppUser:System.Security.Claims.ClaimsIdentity
    {
        
        public string Username { get; set; }

        public AppUser(string username) : base("custom")
        {
            Username = username;
        }

        public AppUser(ClaimsIdentity identity) : base(identity)
        {
            Username = identity.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
        }
    }
}
﻿using Microsoft.AspNetCore.Identity;

namespace JWTAuthenticationServer.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; }
    }
}

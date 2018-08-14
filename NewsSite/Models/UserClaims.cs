using NewsSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace NewsSite.Models
{
    public class UserClaims
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IList<Claim> IdentityUserClaim { get; set; }
    }
}

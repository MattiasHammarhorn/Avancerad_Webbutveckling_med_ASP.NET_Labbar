using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NewsSite.Entities
{
    public class NewsSiteDbContext : IdentityDbContext<ApplicationUser>
    {
        public NewsSiteDbContext(DbContextOptions<NewsSiteDbContext> options)
            : base(options)
        {

        }
    }
}

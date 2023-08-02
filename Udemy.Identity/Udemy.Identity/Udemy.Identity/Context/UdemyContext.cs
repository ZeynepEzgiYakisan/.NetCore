using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Identity.Entities;

namespace Udemy.Identity.Context
{
    public class UdemyContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public UdemyContext(DbContextOptions<UdemyContext> options) : base(options)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core;

namespace prefinals_auth_ampong_jemicholouise.Data
{
    public class prefinals_auth_ampong_jemicholouiseContext : DbContext
    {
        public prefinals_auth_ampong_jemicholouiseContext (DbContextOptions<prefinals_auth_ampong_jemicholouiseContext> options)
            : base(options)
        {
        }

        public DbSet<Core.User> User { get; set; } = default!;
    }
}

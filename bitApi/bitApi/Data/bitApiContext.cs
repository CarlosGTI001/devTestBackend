using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bitApi;

namespace bitApi.Data
{
    public class bitApiContext : DbContext
    {
        public bitApiContext (DbContextOptions<bitApiContext> options)
            : base(options)
        {
        }

        public DbSet<bitApi.announcement> announcement { get; set; } = default!;
    }
}

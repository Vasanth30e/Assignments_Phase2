using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_API.Models;

namespace CRUD_API.Data
{
    public class CrudAPIDbContext : DbContext
    {
        public CrudAPIDbContext (DbContextOptions<CrudAPIDbContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD_API.Models.Movie> Movie { get; set; } = default!;
    }
}

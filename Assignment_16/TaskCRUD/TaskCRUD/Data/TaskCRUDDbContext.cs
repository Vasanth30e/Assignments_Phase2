using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskCRUD.Models;

namespace TaskCRUD.Data
{
    public class TaskCRUDDbContext : DbContext
    {
        public TaskCRUDDbContext (DbContextOptions<TaskCRUDDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskCRUD.Models.Task> Task { get; set; } = default!;
    }
}

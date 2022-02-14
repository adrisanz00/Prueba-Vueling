using DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<ModelTransaction> Transactions { get; set; } = null;
        public DbSet<ModelCurrency> Currencies { get; set; } = null;

    }
}


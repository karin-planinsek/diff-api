using Microsoft.EntityFrameworkCore;
using DiffApi.Models;

namespace DiffApi.Db
{
    public class DiffContext : DbContext
    {
        public DiffContext(DbContextOptions<DiffContext> options) : base(options) { }

        public DbSet<LeftDiff> LeftDiffs { get; set; }
        public DbSet<RightDiff> RightDiffs { get; set; }
    }
}

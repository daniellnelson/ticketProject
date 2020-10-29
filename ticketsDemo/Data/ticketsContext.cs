using Microsoft.EntityFrameworkCore;
using ticketsDemo.Models;

namespace ticketsDemo.Data
{
    public class ticketsContext : DbContext
    {
        public ticketsContext(DbContextOptions<ticketsContext> options)
            : base(options)
        {
        }

        public DbSet<tickets> tickets { get; set; }

        public DbSet<comments> submitter { get; set; }

        public DbSet<status> status { get; set; }
        public DbSet<comments>  comments{ get; set; }

        public DbSet<assignee> assignee { get; set; }

        public DbSet<ticketsDemo.Models.submitter> submitter_1 { get; set; }
    }
}
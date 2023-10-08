using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace Dispatch_app.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
: base(options)
        {
        }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Tractors> Tractors { get; set; }
        public virtual DbSet<Trailers> Trailers { get; set; }

        public virtual DbSet<Loads> Loads2 { get; set; }  //change made for Loads2





        public virtual DbSet<test> test { get; set; }
    }
}

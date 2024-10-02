using Microsoft.EntityFrameworkCore;
using WebNB.Models;
using WebNB.Models.Entities;

namespace WebNB.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Gia_CLS> Gia_CLS { get; set; }

        public DbSet<Gia_DV> Gia_DV { get; set; }

        public DbSet<Gia_GIUONG> Gia_GIUONG { get; set; }
        
        public DbSet<Gia_PTTT> Gia_PTTT { get; set; }

        //public DbSet<Import_GiaCLS> Import_GiaCLS { get; set; }

        internal string? Find(int? sTT)
        {
            throw new NotImplementedException();
        }
    }
}

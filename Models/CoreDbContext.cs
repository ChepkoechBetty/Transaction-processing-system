using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TPS.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAtm> TAtms { get; set; }
        public virtual DbSet<TUser> TUsers { get; set; }
        public virtual DbSet<TUserAccount> TUserAccounts { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-AKKIQ4U;Database=TPS;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=sa;Password=chep@610;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TUser>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
            modelBuilder.Entity<TUser>(entity => { entity.HasIndex(e => e.UserName).IsUnique(); });
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

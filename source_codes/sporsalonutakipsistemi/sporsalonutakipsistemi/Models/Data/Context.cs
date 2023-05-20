using Microsoft.EntityFrameworkCore;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-4JD2R8F; database=sporsalonutakip; integrated security=true;  TrustServerCertificate=True  ");

            //optionsBuilder.UseSqlServer("Data Source=SQL8005.site4now.net;Initial Catalog=db_a97bf8_turkmen;User Id=db_a97bf8_turkmen_admin;Password=enesusta2003.");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>()
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserInfo>()
                .HasOne(u => u.Price)
                .WithMany()
                .HasForeignKey(u => u.PriceId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<SiteInfo> SiteInfos { get; set; }
        public DbSet<Price> Prices { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<SiteAdressInfo> SiteAdressInfos { get; set; }

        public DbSet<Revenue> Revenues { get; set; }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<EmailSetting> EmailSettings { get; set; }
    }
}

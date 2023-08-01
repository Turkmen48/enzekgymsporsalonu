using Microsoft.EntityFrameworkCore;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=DESKTOP-4JD2R8F; database=sporsalonutakip; integrated security=true;  TrustServerCertificate=True  ");

            //relase
            //optionsBuilder.UseMySQL("server=localhost;Allow Zero Datetime=True;database=enzekgym_;user=enzekgym;password=enesusta2003.;");

            ////developer
            optionsBuilder.UseMySQL("server=localhost;Allow Zero Datetime=True;database=sporsalonutakip;user=root;password=enesusta2003.;");

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

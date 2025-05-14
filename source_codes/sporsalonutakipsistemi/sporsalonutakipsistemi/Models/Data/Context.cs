using Microsoft.EntityFrameworkCore;

namespace sporsalonutakipsistemi.Models.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            ////context
            optionsBuilder.UseMySQL("server=localhost;Allow Zero Datetime=True;database=sevvalsporsalonu;user=root;password=enesusta2003.;");

        }

       

        public DbSet<Price> Prices { get; set; }

        public DbSet<SiteInfo> SiteInfos { get; set; }
  

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<SiteAdressInfo> SiteAdressInfos { get; set; }

     
    }
}

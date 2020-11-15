using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service.Resource;
using System.Data.Entity;


namespace SimpleEcommerceWebsite.SimpleEcomerceDbContext
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext() : base(ConfigurationInfomation.ConnectionString())
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Allcode> Allcodes { get; set; }
    }
}
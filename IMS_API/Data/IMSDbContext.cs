using IMS_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace IMS_API.Data
{
    public class IMSDbContext :DbContext
    {
        public IMSDbContext(DbContextOptions<IMSDbContext> options) : base(options) 
        { 

        }
        public DbSet<Login> M_USER_MANAGEMENT { get; set; }
        public DbSet<financial__YearSelection> M_FY_YEAR { get; set; }
        public DbSet<T_QuotationMain> T_QUOTATION_REPORT { get; set; }   
       
        public DbSet<T_InvoiceItem> T_INVOICE_ITEM_REPORT { get; set; }
        public DbSet<T_InvoiceMain> T_INVOICE_REPORT { get; set; }
        public DbSet<T_QUOTATION_ITEM> T_QUOTATOIN_ITEM_REPORT { get; set; }
        public DbSet<Quotation> QUOTATION_VIEW { get; set; }
        public DbSet<Company> M_COMPANY { get; set; }   
       // public DbSet<QUOTATION_ITEM> QUOTATION_VIEW { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasNoKey();
            modelBuilder.Entity<Company>().HasNoKey();
            modelBuilder.Entity<financial__YearSelection>().HasNoKey();
              //modelBuilder.Entity<QUOTATION_ITEM>()
                //.HasKey();

            //modelBuilder.Entity<Quotation>()
            //    .HasMany(q => q.QuotationItemValue)
            //    .WithOne()
            //    .HasForeignKey(qi => qi.QUOTATION_NO);


            modelBuilder.Entity<T_QuotationMain>().HasNoKey();
            modelBuilder.Entity<T_QUOTATION_ITEM>().HasNoKey();
            modelBuilder.Entity<T_InvoiceItem>().HasNoKey();    
           modelBuilder.Entity<T_InvoiceMain>().HasNoKey();
            modelBuilder.Entity<Quotation>().HasNoKey();    
          //  modelBuilder.Entity<M_USER_MANAGEMENT>().ToTable(nameof(M_USER_MANAGEMENT));
        }

        }
}

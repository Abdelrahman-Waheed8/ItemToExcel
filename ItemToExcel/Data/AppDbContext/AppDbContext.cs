using ItemToExcel.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ItemToExcel.Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(i =>
            {
                i.HasKey(x => x.Id);
                i.Property(x => x.Name).IsRequired().HasMaxLength(100);
                i.Property(x => x.BeforeDiscount).IsRequired().HasPrecision(18,2);
                i.Property(x => x.AfterDiscount).IsRequired().HasPrecision(18, 2);
                i.HasOne(i => i.Category).WithMany(c => c.Items).HasForeignKey(i => i.CategoryId).IsRequired();

                i.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_Before_Discount", "[BeforeDiscount] > 0");
                    t.HasCheckConstraint("CK_After_Discount", "[AfterDiscount] > 0");
                    t.HasCheckConstraint("CK_Check_Valid_AfterDiscount", "[AfterDiscount] <= [BeforeDiscount]");
                });
            });

            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(x => x.Id);
                c.Property(x => x.Name).IsRequired().HasMaxLength(30);
            });
        }
    }
}

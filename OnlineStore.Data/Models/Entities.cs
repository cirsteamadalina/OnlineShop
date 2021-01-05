namespace OnlineStore.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using OnlineStore.Data.Models;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemOrder> ItemOrder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
               .HasMany(c => c.ItemOrder)
               .WithRequired(o => o.Order)
               .HasForeignKey(s => s.OrderId);

            modelBuilder.Entity<Item>()
              .HasMany(c => c.ItemOrder)
              .WithRequired(o => o.Item)
              .HasForeignKey(s => s.ItemId);
        }
    }
}

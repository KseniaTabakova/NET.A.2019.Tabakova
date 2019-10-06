namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BankModel : DbContext
    {
        public BankModel()
            : base("name=BankModel")
        {
        }

        public virtual DbSet<AccountOwner> AccountOwners { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountOwner>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountOwner)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Number)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<AccountType>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountType)
                .WillCascadeOnDelete(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;

class Database : DbContext  // DbContext è un'estensione fornita da entity framework
{
    public DbSet<User> Users { get; set; }  // Tabella degli utenti

    public DbSet<Subscription> Subscriptions { get; set; } // Tabella degli abbonamenti

    public DbSet<Transaction> Transactions { get; set; } // Tabella delle transazioni

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source = database.db");  // Usa un database SQLite
    }
}
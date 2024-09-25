using Microsoft.EntityFrameworkCore;

class Database : DbContext  // DbContext è un'estensione fornita da entity framework
{
    public DbSet<User> Users { get; set; }  // Tabella degli utenti

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source = database.db");  // Usa un database SQLite
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserManagement.Domain.Entities;

public class UserDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly IConfiguration Configuration;

    public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Documents)
            .WithOne()
            .HasForeignKey(d => d.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Addresses)
            .WithOne()
            .HasForeignKey(a => a.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Contacts)
            .WithOne()
            .HasForeignKey(c => c.Id);

        modelBuilder.Entity<Email>()
            .HasOne(e => e.Contact)
            .WithMany(c => c.Emails)
            .HasForeignKey(e => e.ContactId);

        modelBuilder.Entity<Phone>()
            .HasOne(p => p.Contact)
            .WithMany(c => c.Phones)
            .HasForeignKey(p => p.ContactId);

    }
}

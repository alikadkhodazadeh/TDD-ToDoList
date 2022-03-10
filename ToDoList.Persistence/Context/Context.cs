using ToDoList.Persistence.Mappings;

namespace ToDoList.Persistence;

public sealed class Context : DbContext
{
    public Context(DbContextOptions<Context> options) 
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        const string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ToDo_db";
        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddSequentialGuidForIdConvention();
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.Seed();
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<Domain.Task> Tasks { get; set; }
}

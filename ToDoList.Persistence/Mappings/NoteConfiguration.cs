namespace ToDoList.Persistence.Mappings;

public sealed class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Title)
            .HasMaxLength(70);

        builder
            .Property(x => x.Description)
            .HasMaxLength(500);
    }
}

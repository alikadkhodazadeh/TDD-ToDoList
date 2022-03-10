namespace ToDoList.Persistence.Mappings;

public sealed class TaskConfiguration : IEntityTypeConfiguration<Domain.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Task> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Title)
            .HasMaxLength(70);

        builder
            .Property(x => x.IsDone)
            .IsRequired();

        builder
            .HasOne(x=>x.Note)
            .WithMany(x=>x.Tasks)
            .HasForeignKey(x=>x.NoteId);
    }
}
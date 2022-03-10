namespace ToDoList.Persistence;

internal static class ContextSeed
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.SeedNotes();
    }

    public static void SeedNotes(this ModelBuilder builder)
    {
        var note = new Note("First day", "Learn TDD");
        note.ChangeId(Guid.Parse("7eb9e411-b2a0-ec11-9cb7-ebcb6b5cfbf3"));
        builder.Entity<Note>(n =>
        {
            n.HasData(note);
        });
    }
}
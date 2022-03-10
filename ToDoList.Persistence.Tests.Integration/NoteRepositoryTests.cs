namespace ToDoList.Persistence.Tests.Integration;

public class NoteRepositoryTests
{
    [Fact]
    public void Should_Return_Notes()
    {
        // Arrange
        var context = new ContextFactory().CreateDbContext();
        var noteRepository = new NoteRepositoryFactory().Create();

        // Act
        var notes = noteRepository.GetAll();

        //
        notes.Should().HaveCountGreaterThanOrEqualTo(1);
    }
}

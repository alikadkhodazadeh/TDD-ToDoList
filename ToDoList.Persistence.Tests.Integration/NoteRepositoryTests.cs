namespace ToDoList.Persistence.Tests.Integration;

public class NoteRepositoryTests
{
    private readonly INoteRepository _noteRepository;
    public NoteRepositoryTests()
    {
        _noteRepository = new NoteRepositoryFactory().Create();
    }

    [Fact]
    public void Should_Return_Notes()
    {
        // Arrange

        // Act
        var notes = _noteRepository.GetAll();

        // Assert
        notes.Should().HaveCountGreaterThanOrEqualTo(1);
    }
}

namespace ToDoList.Persistence.Tests.Unit;

public class NoteRepositoryTests
{
    private readonly INoteRepository _noteRepository;
    public NoteRepositoryTests()
    {
        _noteRepository = new NoteRepositoryFactory().Create();
    }

    [Fact]
    public void Should_Add_New_Note()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        var note = noteBuilder.Build();

        // Act
        _noteRepository.Create(note);

        // Assert
        _noteRepository.Notes.Should().Contain(note);
    }
    [Fact]
    public void Should_Return_List_Of_Notes()
    {
        // Act
        var notes = _noteRepository.Notes;

        // Assert
        notes.Should().HaveCountGreaterThanOrEqualTo(0);
    }

    [Fact]
    public void Should_Return_Get_Note_By_Id()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        var note = noteBuilder.Build();

        // Act
        _noteRepository.Create(note);
        var actual = _noteRepository.GetById(note.Id);

        // Assert
        actual.Should().Be(note);
    }
}

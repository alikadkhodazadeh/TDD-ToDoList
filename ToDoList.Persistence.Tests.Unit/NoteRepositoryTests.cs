namespace ToDoList.Persistence.Tests.Unit;

public class NoteRepositoryTests
{
    private readonly INoteRepository _noteRepository;
    private readonly NoteBuilder _noteBuilder;
    public NoteRepositoryTests()
    {
        _noteRepository = new NoteRepositoryFactory().Create();
        _noteBuilder = new NoteBuilder();
    }

    [Fact]
    public void Should_Add_New_Note()
    {
        // Arrange
        var note = _noteBuilder.Build();

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
        var note = _noteBuilder.Build();

        // Act
        _noteRepository.Create(note);
        var actual = _noteRepository.GetById(note.Id);

        // Assert
        actual.Should().Be(note);
    }

    [Fact]
    public void Should_Return_Null_When_Id_Is_Null()
    {
        // Arrange
        var note = _noteBuilder.Build();

        // Act
        _noteRepository.Create(note);
        var actual = _noteRepository.GetById(Guid.Empty);

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public void Should_Delete_Note()
    {
        // Arrange
        var id = Guid.NewGuid();
        var note = _noteBuilder.WithId(id).Build();

        // Act
        _noteRepository.Create(note);
        _noteRepository.Delete(id);

        // Assert
        _noteRepository.Notes.Should().NotContain(note);
    }
}

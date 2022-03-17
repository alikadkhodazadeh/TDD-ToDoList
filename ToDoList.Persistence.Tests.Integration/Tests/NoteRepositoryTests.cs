namespace ToDoList.Persistence.Tests.Integration;

public class NoteRepositoryTests : IClassFixture<NoteFixture>
{
    private readonly INoteRepository _noteRepository;
    private readonly NoteBuilder _noteBuilder;
    private TransactionScope _transactionScope;
    public NoteRepositoryTests(NoteFixture database)
    {
        _noteRepository = database.NoteRepository;
        _noteBuilder = new NoteBuilder();
        _transactionScope = database.Transaction;
    }

    [Fact]
    public void Should_Return_All_Notes()
    {
        // Act
        var notes = _noteRepository.GetAll();

        // Assert
        notes.Should().HaveCountGreaterThanOrEqualTo(1);
    }

    [Fact]
    public void Should_Create_Note()
    {
        // Arrange
        var note =  _noteBuilder.WithTitle(nameof(Should_Create_Note)).Build();

        // Act
        _noteRepository.Create(note);

        //Assert
        _noteRepository.GetAll().Should().Contain(note);
    }

    [Fact]
    public void Should_Get_Note_By_Id()
    {
        // Arrange
        var note =  _noteBuilder.WithTitle(nameof(Should_Get_Note_By_Id)).Build();
        var id = _noteRepository.Create(note);

        // Act
        var actual = _noteRepository.GetById(id);

        //Assert
        actual.Should().Be(note);
    }

    [Fact]
    public void Should_Return_Id_Of_The_Created_Note()
    {
        // Arrange
        var note = _noteBuilder.WithTitle(nameof(Should_Return_Id_Of_The_Created_Note)).Build();

        // Act
        var id = _noteRepository.Create(note);

        // Assert
        id.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Return_Id_Of_The_Updated_Note()
    {
        // Arrange
        var createNote = _noteBuilder.Build();
        var updateNote = _noteBuilder.WithTitle(nameof(Should_Return_Id_Of_The_Updated_Note)).Build();

        // Act
        var newId = _noteRepository.Create(createNote);
        updateNote.ChangeId(newId);
        var id = _noteRepository.Update(updateNote);

        // Assert
        id.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Delete_Existing_Note()
    {
        // Arrange
        var note = _noteBuilder.WithTitle(nameof(Should_Delete_Existing_Note)).Build();
        var id = _noteRepository.Create(note);

        // Act
        _noteRepository.Delete(id);

        // Assert
        _noteRepository.GetById(id).Should().BeNull();
    }

    [Fact]
    public void Should_Update_Note()
    {
        // Arrange
        var createNote = _noteBuilder.Build();
        var updateNote = _noteBuilder.WithTitle(nameof(Should_Update_Note)).Build();

        // Act
        var id = _noteRepository.Create(createNote);
        updateNote.ChangeId(id);
        _noteRepository.Update(updateNote);
        var actual = _noteRepository.GetById(createNote.Id);

        // Assert
        actual?.Title.Should().Be(updateNote.Title);
    }
}

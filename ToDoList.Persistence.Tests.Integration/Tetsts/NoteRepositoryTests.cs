namespace ToDoList.Persistence.Tests.Integration;

public class NoteRepositoryTests : IClassFixture<DatabaseFixture>
{
    private readonly INoteRepository _noteRepository;
    private readonly NoteBuilder _noteBuilder;
    private TransactionScope _transactionScope;
    public NoteRepositoryTests(DatabaseFixture database)
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
}

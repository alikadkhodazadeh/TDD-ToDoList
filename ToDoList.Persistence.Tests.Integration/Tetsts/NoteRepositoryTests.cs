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
}

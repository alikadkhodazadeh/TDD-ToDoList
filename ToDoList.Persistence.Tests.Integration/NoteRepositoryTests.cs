using System.Transactions;
using ToDoList.Domain.Tests.Unit.Builders;

namespace ToDoList.Persistence.Tests.Integration;

public class NoteRepositoryTests : IClassFixture<DatabaseFixture>
{
    private readonly INoteRepository _noteRepository;
    private readonly NoteBuilder _noteBuilder;
    public NoteRepositoryTests(DatabaseFixture database)
    {
        _noteRepository = database.NoteRepository;
        _noteBuilder = new NoteBuilder();
    }

    [Fact]
    public void Should_Return_Notes()
    {
        // Act
        var notes = _noteRepository.GetAll();

        // Assert
        notes.Should().HaveCountGreaterThanOrEqualTo(3);
    }

    [Fact]
    public void Should_Create_Note()
    {
        // Arrange
        var note = _noteBuilder.WithTitle("Create Test").WithDescription("Test Test Test").Build();

        // Act
        _noteRepository.Create(note);

        //Assert
        _noteRepository.GetAll().Should().Contain(note);
    }

    [Fact]
    public void Should_Get_Note_By_Id()
    {
        // Arrange
        var note = _noteBuilder.WithTitle("Get By Id Test").WithDescription("Test Test Test").Build();

        // Act
        _noteRepository.Create(note);
        var actual = _noteRepository.GetById(note.Id);

        //Assert
        actual.Should().NotBeNull();
        actual.Should().Be(note);
    }

    [Fact]
    public void Should_Return_Id_Of_The_Created_Note()
    {
        // Arrange
        var note = _noteBuilder.Build();

        // Act
        var id = _noteRepository.Create(note);

        // Assert
        id.Should().NotBe(Guid.Empty);
        id.Should().NotBeEmpty();
    }
}

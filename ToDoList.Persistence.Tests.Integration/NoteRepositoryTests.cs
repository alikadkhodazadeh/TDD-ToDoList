using System.Transactions;
using ToDoList.Domain.Tests.Unit.Builders;

namespace ToDoList.Persistence.Tests.Integration;

public class NoteRepositoryTests : IClassFixture<DatabaseFixture>
{
    private readonly INoteRepository _noteRepository;
    public NoteRepositoryTests(DatabaseFixture database)
    {
        _noteRepository = database.NoteRepository;
    }

    [Fact]
    public void Should_Return_Notes()
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
        var note = new NoteBuilder().WithTitle("Create Test").WithDescription("Test Test Test").Build();
        using var scope = new TransactionScope();

        // Act
        _noteRepository.Create(note);

        //Assert
        _noteRepository.GetAll().Should().Contain(note);
    }
}

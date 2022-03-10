using ToDoList.Persistence.Repositories;

namespace ToDoList.Persistence.Tests.Unit;

public class NoteRepositoryTests
{
    [Fact]
    public void Should_Add_New_Note()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        var note = noteBuilder.Build();
        var noteRepository = new NoteRepositoryFactory().Create();

        // Act
        noteRepository.Create(note);

        // Assert
        noteRepository.Notes.Should().Contain(note);
    }

    [Fact]
    public void Equality_Should_Be_On_Id()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        var id = Guid.NewGuid();
        var note1 = noteBuilder.WithId(id).Build();
        var note2 = noteBuilder.WithId(id).WithTitle("Test").Build();

        // Assert
        note1.Should().Be(note2);
    }
}

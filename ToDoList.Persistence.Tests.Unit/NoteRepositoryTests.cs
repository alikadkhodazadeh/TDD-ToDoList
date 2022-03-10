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
}

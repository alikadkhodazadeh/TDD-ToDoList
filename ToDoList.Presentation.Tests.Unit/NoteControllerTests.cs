using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Presentation.Tests.Unit;

public class NoteControllerTests
{
    private readonly NotesController _notesController;
    private readonly INoteRepository _noteRepository;
    private readonly NoteBuilder _noteBuilder;
    public NoteControllerTests()
    {
        _noteRepository = Substitute.For<INoteRepository>();
        _notesController = new NotesController(_noteRepository);
        _noteBuilder = new NoteBuilder();
    }

    [Fact]
    public void Should_Return_All_Notes()
    {
        // Arrange

        // Act
        var notes = _notesController.Get();

        // Assert
        _noteRepository.Received().GetAll();
    }

    [Fact]
    public void Should_Return_List_Of_All_Notes()
    {
        // Arrange
        _noteRepository.GetAll().Returns(new List<Note>());

        // Act
        var notes = _notesController.Get();

        // Assert
        notes.Should().BeOfType<List<Note>>();
    }

    [Fact]
    public void Should_Create_Note()
    {
        // Arrange
        var note = _noteBuilder.Build();

        // Act
        _notesController.Create(note);

        // Assert
        _noteRepository.Received().Create(note);
    }
}

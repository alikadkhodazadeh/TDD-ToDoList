using NSubstitute;
using System.Collections.Generic;
using ToDoList.Application;
using ToDoList.Domain;
using ToDoList.Presentation.Controllers;

namespace ToDoList.Presentation.Tests.Unit;

public class NoteControllerTests
{
    private readonly NotesController _notesController;
    private readonly INoteRepository _noteRepository;
    public NoteControllerTests()
    {
        _noteRepository = Substitute.For<INoteRepository>();
        _notesController = new NotesController(_noteRepository);
    }

    [Fact]
    public void Should_Return_All_Notes()
    {
        // Arrange
        var repository = Substitute.For<INoteRepository>();
        var controller = new NotesController(repository);

        // Act
        var notes = controller.Get();

        // Assert
        repository.Received().GetAll();
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
}

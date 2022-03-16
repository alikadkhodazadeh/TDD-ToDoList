using NSubstitute;
using ToDoList.Application;
using ToDoList.Presentation.Controllers;

namespace ToDoList.Presentation.Tests.Unit;

public class NoteControllerTests
{
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
}

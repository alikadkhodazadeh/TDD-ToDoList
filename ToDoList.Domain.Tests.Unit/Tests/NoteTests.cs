namespace ToDoList.Domain.Tests.Unit;

public class NoteTests
{
    [Fact]
    public void Constructor_Should_Construct_Note_Property()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        const string title = "Note-1";
        const string description = "Test-1";

        // Act
        var note = noteBuilder.WithTitle(title).WithDescription(description).Build();

        // Assert
        note.Should().NotBeNull();
        note.Title.Should().Be(title);
        note.Description.Should().Be(description);
        note.Tasks.Should().BeEmpty();
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Title_Is_Not_Provided()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        const string title = "";

        // Act
        Action note = () => noteBuilder.WithTitle(title).Build();

        // Assert
        note.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Description_Is_Not_Provided()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        const string description = "";

        // Act
        Action note = () => noteBuilder.WithTitle(description).Build();

        // Assert
        note.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Should_Added_Task()
    {
        // Arrange
        var noteBuilder = new NoteBuilder();
        var taskBuilder = new TaskBuilder();
        var note = noteBuilder.Build();
        var task = taskBuilder.Build();

        // Act
        note.AddTask(task);

        // Assert
        note.Tasks.Should().Contain(task);
    }
}

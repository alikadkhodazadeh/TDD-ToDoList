namespace ToDoList.Domain.Tests.Unit;

public class NoteTests
{
    private readonly NoteBuilder _noteBuilder;
    private readonly TaskBuilder _taskBuilder;
    public NoteTests()
    {
        _noteBuilder = new NoteBuilder();
        _taskBuilder = new TaskBuilder();
    }

    [Fact]
    public void Constructor_Should_Construct_Note_Property()
    {
        // Arrange
        const string title = "Note-1";
        const string description = "Test-1";

        // Act
        var note = _noteBuilder.WithTitle(title).WithDescription(description).Build();

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
        const string title = "";

        // Act
        Action note = () => _noteBuilder.WithTitle(title).Build();

        // Assert
        note.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Description_Is_Not_Provided()
    {
        // Arrange
        const string description = "";

        // Act
        Action note = () => _noteBuilder.WithTitle(description).Build();

        // Assert
        note.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Should_Added_Task()
    {
        // Arrange
        var note = _noteBuilder.Build();
        var task = _taskBuilder.Build();

        // Act
        note.AddTask(task);

        // Assert
        note.Tasks.Should().Contain(task);
    }
}

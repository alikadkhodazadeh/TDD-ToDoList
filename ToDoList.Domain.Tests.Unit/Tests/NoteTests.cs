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
        Action note = () => _noteBuilder.WithDescription(description).Build();

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

    [Fact]
    public void Should_Change_State_The_Task()
    {
        // Arrange
        var note = _noteBuilder.Build();
        var task = _taskBuilder.Build();

        // Act
        note.AddTask(task); // default false
        note.ChangeStateTask(task.Id);

        // Assert
        note.Tasks?.SingleOrDefault(t => t.Id.Equals(task.Id))?.IsDone.Should().BeTrue();
    }

    [Fact]
    public void Should_Throw_InvalidOperationException_ChangeState_Method_Id_Is_Empty()
    {
        // Arrange
        var note = _noteBuilder.Build();

        // Act
        Action changeStateTask = () => note.ChangeStateTask(Guid.Empty);

        // Assert
        changeStateTask.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Should_Throw_ArgumentNullException_ChangeState_Method_Task_Is_Null()
    {
        // Arrange
        var note = _noteBuilder.Build();
        var id = Guid.NewGuid();

        // Act
        Action changeStateTask = () => note.ChangeStateTask(id);

        // Assert
        changeStateTask.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Should_Return_ToString_Method_Equal_To_Title()
    {
        // Arrange
        var note = _noteBuilder.Build();

        // Act
        var result = note.ToString();

        // Assert
        result.Should().Be(note.Title);
    }
}

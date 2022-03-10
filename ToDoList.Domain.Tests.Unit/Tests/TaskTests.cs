namespace ToDoList.Domain.Tests.Unit;

public class TaskTests : IClassFixture<IdentifierFixture>
{
    private readonly TaskBuilder _taskBuilder;
    private readonly IdentifierFixture _identifierFixture;
    public TaskTests(IdentifierFixture identifierFixture)
    {
        _taskBuilder = new TaskBuilder();
        _identifierFixture = identifierFixture;
    }

    [Fact]
    public void Counstructor_Should_Construct_Task_Property()
    {
        // Arrange -> Setup
        const string title = "Unit Testing";

        // Act -> Exercise
        var task = _taskBuilder.WithTitle(title).Build();

        // Assert -> Verify
        task.Title.Should().Be(title);
        task.IsDone.Should().BeFalse();
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Title_Is_Not_Provided()
    {
        // Arrange -> Setup
        const string title = "";

        // Act -> Exercise
        Action task = () => _taskBuilder.WithTitle(title).Build();

        // Assert -> Verify
        task.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Should_Return_IsDone_True()
    {
        // Arrange -> Setup
        var task = _taskBuilder.Build();

        // Act -> Exercise
        task.Done();

        // Assert -> Verify
        task.IsDone.Should().BeTrue();
    }

    [Fact]
    public void Should_Change_State_IsDone_Property()
    {
        // Arrange -> Setup
        var task = _taskBuilder.Build(); // default false

        // Act -> Exercise
        task.ChangeState();

        // Assert -> Verify
        task.IsDone.Should().BeTrue();
    }
}

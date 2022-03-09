namespace ToDoList.Domain.Tests.Unit;

public class TaskTests
{
    [Fact]
    public void Counstructor_Should_Construct_Task_Property()
    {
        // Arrange -> Setup
        var taskBuilder = new TaskBuilder();
        const string title = "Unit Testing";

        // Act -> Exercise
        var task = taskBuilder.WithTitle(title).Build();

        // Assert -> Verify
        task.Title.Should().Be(title);
        task.IsDone.Should().BeFalse();
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Title_Is_Not_Provided()
    {
        // Arrange -> Setup
        var taskBuilder = new TaskBuilder();

        // Act -> Exercise
        Action task = () => taskBuilder.WithTitle(null).Build();

        // Assert -> Verify
        task.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Should_Return_Is_Done_True()
    {
        // Arrange -> Setup
        var taskBuilder = new TaskBuilder();
        var task = taskBuilder.Build();

        // Act -> Exercise
        task.Done();

        // Assert -> Verify
        task.IsDone.Should().BeTrue();
    }
}

namespace ToDoList.Domain.Tests.Unit;

public class TaskTests
{
    [Fact]
    public void Counstructor_Should_Task_Property()
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
}

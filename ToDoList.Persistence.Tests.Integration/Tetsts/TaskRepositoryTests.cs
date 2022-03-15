namespace ToDoList.Persistence.Tests.Integration;

public class TaskRepositoryTests : IClassFixture<TaskFixture>
{
    private readonly ITaskRepository _taskRepository;
    public TaskRepositoryTests(TaskFixture taskFixture)
    {
        _taskRepository = taskFixture.TaskRepository;
    }

    [Fact]
    public void Should_Return_All_Tasks()
    {
        // Act
        var tasks = _taskRepository.GetAll();

        // Assert
        tasks.Should().HaveCountGreaterThanOrEqualTo(1);
    }
}

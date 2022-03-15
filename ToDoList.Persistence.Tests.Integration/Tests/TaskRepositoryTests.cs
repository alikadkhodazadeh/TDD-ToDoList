namespace ToDoList.Persistence.Tests.Integration;

public class TaskRepositoryTests : IClassFixture<TaskFixture>
{
    private readonly ITaskRepository _taskRepository;
    private readonly TaskBuilder _taskBuilder;
    public TaskRepositoryTests(TaskFixture taskFixture)
    {
        _taskRepository = taskFixture.TaskRepository;
        _taskBuilder = taskFixture.TaskBuilder;
    }

    [Fact]
    public void Should_Return_All_Tasks()
    {
        // Act
        var tasks = _taskRepository.GetAll();

        // Assert
        tasks.Should().HaveCountGreaterThanOrEqualTo(3);
    }

    [Fact]
    public void Should_Create_Task()
    {
        // Arrange
        var task = _taskBuilder.WithTitle(nameof(Should_Create_Task)).Build();

        // Act
        var id = _taskRepository.Create(task);

        // Assert
        id.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Get_Task_By_Id()
    {
        // Arrange
        var task = _taskBuilder.WithTitle(nameof(Should_Get_Task_By_Id)).Build();
        var id = _taskRepository.Create(task);

        // Act
        var actual = _taskRepository.GetById(id);

        // Assert
        actual.Should().Be(task);
    }

    [Fact]
    public void Should_Return_Id_Of_The_Created_Task()
    {
        // Arrange
        var task = _taskBuilder.WithTitle(nameof(Should_Return_Id_Of_The_Created_Task)).Build();

        // Act
        var id = _taskRepository.Create(task);

        // Assert
        id.Should().NotBeEmpty();
    }

    [Fact]
    public void Should_Delete_Existing_Task()
    {
        // Arrange
        var task = _taskBuilder.WithTitle(nameof(Should_Delete_Existing_Task)).Build();
        var id = _taskRepository.Create(task);

        // Act
        _taskRepository.Delete(id);
        var actual = _taskRepository.GetById(id);

        // Assert
        actual.Should().BeNull();
    }
}

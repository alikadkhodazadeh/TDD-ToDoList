namespace ToDoList.Persistence.Tests.Integration.Tetsts;

public class TaskRepositoryTests
{
    [Fact]
    public void Should_Return_All_Tasks()
    {
        // Arrange
        var taskRepository = new TaskRepositoryFactory().CreateRepository();

        // Act
        var tasks = taskRepository.GetAll();

        // Assert
        tasks.Should().HaveCountGreaterThanOrEqualTo(1);
    }
}

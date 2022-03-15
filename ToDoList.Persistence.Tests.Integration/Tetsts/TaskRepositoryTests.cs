﻿namespace ToDoList.Persistence.Tests.Integration;

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
        tasks.Should().HaveCountGreaterThanOrEqualTo(1);
    }

    [Fact]
    public void Should_Create_Task()
    {
        // Arrange
        var task = _taskBuilder.Build();

        // Act
        var id = _taskRepository.Create(task);

        // Assert
        id.Should().NotBeEmpty();
    }
}

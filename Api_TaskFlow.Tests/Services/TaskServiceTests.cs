using Business.Services;
using DataAccess.Repositories.Interfaces;
using Models.Responses;
using Moq;

namespace Api_TaskFlow.Tests.Services;

public class TaskServiceTests
{
    [Fact]
    public async Task GetTasksAsync_ShouldReturnSuccessfulResult()
    {
        // Arrange
        var expectedResult = new GenericResult
        {
            IsSuccesfull = true,
            Message = "Consulta exitosa"
        };

        var repositoryMock = new Mock<ITaskRepository>();

        repositoryMock
            .Setup(r => r.GetTasks())
            .ReturnsAsync(expectedResult);

        var service = new TaskService(repositoryMock.Object);

        // Act
        var result = await service.GetTasksAsync();

        // Assert
        Assert.True(result.IsSuccesfull);
        Assert.Equal("Consulta exitosa", result.Message);
    }

    [Fact]
    public async Task GetTaskByIdAsync_ShouldReturnExpectedId()
    {
        // Arrange
        int taskId = 1;

        var expectedResult = new GenericResult
        {
            Id = taskId,
            IsSuccesfull = true
        };

        var repositoryMock = new Mock<ITaskRepository>();

        repositoryMock
            .Setup(r => r.GetTaskById(taskId))
            .ReturnsAsync(expectedResult);

        var service = new TaskService(repositoryMock.Object);

        // Act
        var result = await service.GetTaskByIdAsync(taskId);

        // Assert
        Assert.Equal(taskId, result.Id);
        Assert.True(result.IsSuccesfull);
    }

    [Fact]
    public async Task CreateTaskAsync_ShouldReturnSuccessfulResult()
    {
        // Arrange
        string taskName = "Estudiar GitHub Actions";

        var expectedResult = new GenericResult
        {
            IsSuccesfull = true,
            Message = "Tarea creada"
        };

        var repositoryMock = new Mock<ITaskRepository>();

        repositoryMock
            .Setup(r => r.CreateTask(taskName))
            .ReturnsAsync(expectedResult);

        var service = new TaskService(repositoryMock.Object);

        // Act
        var result = await service.CreateTaskAsync(taskName);

        // Assert
        Assert.True(result.IsSuccesfull);
        Assert.Equal("Tarea eliminada", result.Message);
    }
}
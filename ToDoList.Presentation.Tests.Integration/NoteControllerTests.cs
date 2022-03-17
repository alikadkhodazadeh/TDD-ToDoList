using RESTFulSense.Clients;
using ToDoList.Application.DTOs;
using ToDoList.Persistence;

namespace ToDoList.Presentation.Tests.Integration;

public class NoteControllerTests
{
    private readonly RESTFulApiFactoryClient _restClient;
    private const string _apiRoute = "/api/Notes";
    private readonly NoteBuilder _noteBuilder;
    public NoteControllerTests()
    {
        var webApp = new WebApplicationFactory<Program>();
        var httpClient = webApp.CreateClient();
        _restClient = new RESTFulApiFactoryClient(httpClient);
        _noteBuilder = new NoteBuilder();
    }

    [Fact]
    public async void Should_Get_All_Notes()
    {
        // Act
        var actual = await _restClient.GetContentAsync<List<Note>>(_apiRoute);

        // Assert
        actual.Should().HaveCountGreaterThanOrEqualTo(1);
    }

    [Fact]
    public async void Should_Create_A_New_Note()
    {
        // Arrange
        var command = new NoteDto
        {
            Title = nameof(Should_Create_A_New_Note),
            Description = "Test",
        };

        // Act
        var id = await _restClient.PostContentAsync<NoteDto, Guid>(_apiRoute, command);
        var notes = await _restClient.GetContentAsync<List<Note>>(_apiRoute);

        // Assert
        notes.Should().ContainSingle(n => n.Id == id);

        // Teardown
        await _restClient.DeleteContentAsync($"{_apiRoute}/{id}");
    }

    [Fact]
    public async void Should_Return_Note_By_Id()
    {
        // Arrange
        var command = new NoteDto
        {
            Title = nameof(Should_Return_Note_By_Id),
            Description = "Test",
        };

        // Act 
        var id = await _restClient.PostContentAsync<NoteDto, Guid>(_apiRoute, command);
        var actual = await _restClient.GetContentAsync<Note>($"{_apiRoute}/{id}");

        // Assert
        actual.Should().NotBeNull();

        // Teardown
        await _restClient.DeleteContentAsync($"{_apiRoute}/{id}");
    }

    [Fact]
    public async void Should_Update_Existing_Note()
    {
        // Arrange
        var command = new NoteDto
        {
            Title = "update test",
            Description = "test test",
        };
        var id = await _restClient.PostContentAsync<NoteDto, Guid>(_apiRoute, command);
        var name = nameof(Should_Update_Existing_Note);
        var updateNote = new NoteDto
        {
            Title = name,
            Description = name
        };

        // Act
        var updateId = await _restClient.PutContentAsync($"{_apiRoute}/{id}", updateNote);
        var note = await _restClient.GetContentAsync<Note>($"{_apiRoute}/{id}");

        // Assert
        note.Title.Should().Be(name);
        note.Description.Should().Be(name);

        // Teardown
        await _restClient.DeleteContentAsync($"{_apiRoute}/{id}");
    }
}

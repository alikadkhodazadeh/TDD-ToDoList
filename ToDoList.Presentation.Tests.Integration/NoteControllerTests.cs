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
        var note = _noteBuilder.WithId(Guid.Empty).WithTitle(nameof(Should_Create_A_New_Note)).Build();
        var command = new NoteDto
        {
            Title = note.Title,
            Description = note.Description,
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
        var note = _noteBuilder.WithId(Guid.Empty).WithTitle(nameof(Should_Return_Note_By_Id)).Build();
        var command = new NoteDto
        {
            Title = note.Title,
            Description = note.Description,
        };

        // Act 
        var id = await _restClient.PostContentAsync<NoteDto, Guid>(_apiRoute, command);
        var actual = await _restClient.GetContentAsync<Note>($"{_apiRoute}/{id}");

        // Assert
        actual.Should().NotBeNull();

        // Teardown
        await _restClient.DeleteContentAsync($"{_apiRoute}/{id}");
    }
}

using RESTFulSense.Clients;

namespace ToDoList.Presentation.Tests.Integration;

public class NoteControllerTests
{
    private readonly RESTFulApiFactoryClient _restClient;
    public NoteControllerTests()
    {
        var webApp = new WebApplicationFactory<Program>();
        var httpClient = webApp.CreateClient();
        _restClient = new RESTFulApiFactoryClient(httpClient);
    }

    [Fact]
    public async void Should_Get_All_Notes()
    {
        // Act
        var actual = await _restClient.GetContentAsync<List<Note>>("/api/Notes");

        // Assert
        actual.Should().HaveCountGreaterThanOrEqualTo(1);
    }
}

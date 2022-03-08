namespace ToDoList.Domain.Tests.Unit;

public partial class NoteTests
{
    [Fact]
    public void Constructor_Should_Construct_Note_Property()
    {
        // Arrange
        const string? title = "Note-1";
        const string? description = "Test-1";

        // Act
        var note = new NoteBuilder().WithTitle(title).WithDescription(description).Build();

        // Assert
        note.Should().NotBeNull();
        note.Title.Should().Be(title);
        note.Description.Should().Be(description);
        note.Tasks
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Title_Is_Not_Provided()
    {
        // Arrange
        const string? title = "";

        // Act
        Action note = () => new NoteBuilder().WithTitle(title).Build();

        // Assert
        note.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_When_Description_Is_Not_Provided()
    {
        // Arrange
        const string? description = "";

        // Act
        Action note = () => new NoteBuilder().WithTitle(description).Build();

        // Assert
        note.Should().ThrowExactly<InvalidOperationException>();
    }
}

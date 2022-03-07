using Xunit;
using FluentAssertions;
using System;

namespace ToDoList.Domain.Tests.Unit
{
    public class NoteTests
    {
        [Fact]
        public void Constructor_ShouldConstructNoteProperty()
        {
            // Arrange
            const string? title = "Note-1";
            const string? description = "Test-1";

            // Act
            var note = new Note(title, description);

            // Assert
            note.Should().NotBeNull();
            note.Title.Should().Be(title);
            note.Description.Should().Be(description);
        }

        [Fact]
        public void Constructor_ShouldThrowException_When_TitleAndDescriptionIsNotProvided()
        {
            // Arrange
            const string? title = "";
            const string? description = "Test-1";

            // Act
            /// I wrote as a function not to throw an InvalidOperationException
            Action note = () => new Note(title, description); 

            // Assert
            note.Should().Throw<Exception>();
            note.Should().ThrowExactly<InvalidOperationException>();
        }
    }
}
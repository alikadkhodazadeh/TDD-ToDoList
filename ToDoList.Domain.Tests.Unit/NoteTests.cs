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
    }
}
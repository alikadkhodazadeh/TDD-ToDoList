namespace ToDoList.Domain.Tests.Unit
{
    public partial class NoteTests
    {
        public class NoteBuilder
        {
            private string? _title = "First day";
            private string? _description = "Learn TDD";
            public NoteBuilder WithTitle(string? title)
            {
                _title = title;
                return this;
            }
            public NoteBuilder WithDescription(string? description)
            {
                _description = description;
                return this;
            }
            public Note Build()
            {
                return new Note(_title, _description);
            }
        }
    }
}
namespace ToDoList.Domain.Tests.Unit.Builders;

public class NoteBuilder
{
    private string _title = "First day";
    private string _description = "Learn TDD";
    private Guid _id;
    public NoteBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }
    public NoteBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
    public NoteBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }
    public Note Build()
    {
        var note = new Note(_title, _description);

        if (_id != Guid.Empty)
            note.ChangeId(_id);

        return note;
    }
}

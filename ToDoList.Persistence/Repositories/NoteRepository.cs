namespace ToDoList.Persistence.Repositories;

internal class NoteRepository : INoteRepository
{
    public NoteRepository()
    {
        Notes = new List<Note>();
    }

    public List<Note> Notes { get; }

    public void Create(Note note)
    {
        Notes.Add(note);
    }
}

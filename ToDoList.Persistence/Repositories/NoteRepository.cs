using ToDoList.Application;
using ToDoList.Domain;

namespace ToDoList.Persistence.Repositories;

internal class NoteRepository : INoteRepository
{
    public IList<Note> Notes => new List<Note>();

    public void Create(Note note)
    {
        Notes.Add(note);
    }
}

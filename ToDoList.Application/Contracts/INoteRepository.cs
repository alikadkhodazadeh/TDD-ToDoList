using ToDoList.Domain;

namespace ToDoList.Application;

public interface INoteRepository
{
    IList<Note> Notes { get; }
    void Create(Note note);
}

namespace ToDoList.Application;

public interface INoteRepository
{
    List<Note> Notes { get; }
    void Create(Note note);
    Note? GetById(Guid id);
    void Delete(Guid id);
}

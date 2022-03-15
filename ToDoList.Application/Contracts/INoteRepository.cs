namespace ToDoList.Application;

public interface INoteRepository : IDisposable
{
    List<Note> GetAll();
    void Create(Note note, bool save);
    Guid Create(Note note);
    Note? GetById(Guid id);


    void Save();
}

namespace ToDoList.Persistence.Repositories;

internal sealed class NoteRepository : INoteRepository
{
    private readonly Context _context;

    public NoteRepository(Context context)
    {
        _context = context;
    }

    public void Create(Note note)
    {
        _context.Notes.Add(note);
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public List<Note> GetAll()
    {
        return _context.Notes.ToList();
    }
}

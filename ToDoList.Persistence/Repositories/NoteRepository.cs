namespace ToDoList.Persistence.Repositories;

internal sealed class NoteRepository : INoteRepository
{
    private readonly Context _context;

    public NoteRepository(Context context)
    {
        _context = context;
    }

    public void Create(Note note, bool save = true)
    {
        _context.Notes.Add(note);
        if (save)
            _context.SaveChanges();
    }

    public List<Note> GetAll()
    {
        return _context.Notes.ToList();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}

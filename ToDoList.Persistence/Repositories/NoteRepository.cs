namespace ToDoList.Persistence.Repositories;

internal sealed class NoteRepository : INoteRepository
{
    private readonly Context _context;

    public NoteRepository(Context context)
    {
        _context = context;
    }

    public void Create(Note note, bool save)
    {
        _context.Notes.Add(note);
        if (save)
            Save();
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

    public Note? GetById(Guid id)
    {
        return _context.Notes.SingleOrDefault(x => x.Id.Equals(id));
    }

    public Guid Create(Note note)
    {
        _context.Notes.Add(note);
        Save();
        return note.Id;
    }
}

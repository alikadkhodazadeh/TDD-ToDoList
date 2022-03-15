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
        return _context.Notes.Find(id);
    }

    public Guid Create(Note note)
    {
        _context.Notes.Add(note);
        Save();
        return note.Id;
    }

    public void Delete(Guid id)
    {
        if(id == Guid.Empty)
            throw new InvalidOperationException(nameof(id));
        var note = _context.Notes.Find(id);
        if (note is null)
            throw new InvalidOperationException(nameof(note));
        _context.Notes.Remove(note);
        Save();
    }
}

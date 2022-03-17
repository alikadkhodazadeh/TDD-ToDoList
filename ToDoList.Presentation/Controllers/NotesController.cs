namespace ToDoList.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteRepository _noteRepository;

    public NotesController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [HttpGet]
    public List<Note> Get() => _noteRepository.GetAll();

    [HttpGet("{id}")]
    public Note? Get(Guid id) => _noteRepository.GetById(id);

    [HttpPost]
    public Guid Create(NoteDto dto) => _noteRepository.Create(new Note(dto.Title, dto.Description));

    [HttpPut("{id}")]
    public void Update(Guid id,NoteDto dto)
    {
        var note = new Note(dto.Title, dto.Description);
        note.ChangeId(id);
        _noteRepository.Update(note);
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id) => _noteRepository.Delete(id);
}

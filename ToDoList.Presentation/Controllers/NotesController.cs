using ToDoList.Application;
using ToDoList.Application.DTOs;
using ToDoList.Domain;

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

    [HttpPost]
    public Guid Create(NoteDto dto) => _noteRepository.Create(new Note(dto.Title, dto.Description));

    [HttpPut]
    public void Update(Note note) => _noteRepository.Update(note);

    [HttpDelete("{id}")]
    public void Delete(Guid id) => _noteRepository.Delete(id);
}

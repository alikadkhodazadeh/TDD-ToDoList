using ToDoList.Application;
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
    public void Create(Note note) => _noteRepository.Create(note);

    [HttpPut]
    public void Update(Note note) => _noteRepository.Update(note);

    [HttpDelete]
    public void Delete(Guid id) => _noteRepository.Delete(id);
}

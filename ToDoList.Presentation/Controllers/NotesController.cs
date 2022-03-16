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
}

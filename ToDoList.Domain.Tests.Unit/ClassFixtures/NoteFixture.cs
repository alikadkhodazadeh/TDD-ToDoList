namespace ToDoList.Domain.Tests.Unit.ClassFixtures
{
    public class NoteFixture : IDisposable
    {
        public NoteFixture()
        {
            NoteBuilder = new NoteBuilder();
            TaskBuilder = new TaskBuilder();
        }

        public NoteBuilder? NoteBuilder { get; private set; }
        public TaskBuilder? TaskBuilder { get; private set; }

        public void Dispose()
        {
            NoteBuilder = null;
            TaskBuilder = null;
        }
    }
}

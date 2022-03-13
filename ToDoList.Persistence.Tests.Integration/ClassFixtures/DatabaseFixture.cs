namespace ToDoList.Persistence.Tests.Integration
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            NoteRepository = new NoteRepositoryFactory().Create();
        }

        public INoteRepository NoteRepository { get; set; }

        public void Dispose()
        {
            NoteRepository.Dispose();
        }
    }
}

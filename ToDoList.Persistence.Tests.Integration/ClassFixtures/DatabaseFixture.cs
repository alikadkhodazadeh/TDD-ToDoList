using System.Transactions;

namespace ToDoList.Persistence.Tests.Integration
{
    public class DatabaseFixture : IDisposable
    {
        private TransactionScope _scope;
        public DatabaseFixture()
        {
            NoteRepository = new NoteRepositoryFactory().Create();
            _scope = new TransactionScope();
        }

        public INoteRepository NoteRepository { get; set; }

        public void Dispose()
        {
            _scope.Dispose();
            NoteRepository.Dispose();
        }
    }
}

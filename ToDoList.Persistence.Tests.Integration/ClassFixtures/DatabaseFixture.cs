using System.Transactions;
using ToDoList.Domain;

namespace ToDoList.Persistence.Tests.Integration
{
    public class DatabaseFixture : IDisposable
    {
        private TransactionScope _scope;
        public DatabaseFixture()
        {
            _scope = new TransactionScope();
            var noteRepository = new NoteRepositoryFactory().Create();

            #region Data Seeding
            noteRepository.Create(new Note("Git", "Learn Git"), false);
            noteRepository.Create(new Note("RegEx", "Learn RegEx"), false);
            noteRepository.Create(new Note("TDD", "Learn TDD"), false);
            noteRepository.Save();
            #endregion

            NoteRepository = noteRepository;
        }

        public INoteRepository NoteRepository { get; set; }

        public void Dispose()
        {
            NoteRepository.Dispose();
            _scope.Dispose();
        }
    }
}

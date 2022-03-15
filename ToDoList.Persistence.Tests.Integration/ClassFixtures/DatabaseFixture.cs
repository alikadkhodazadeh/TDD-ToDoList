using System.Transactions;
using ToDoList.Domain;
using ToDoList.Domain.Tests.Unit.Builders;

namespace ToDoList.Persistence.Tests.Integration
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Transaction = new TransactionScope();
            var noteRepository = new NoteRepositoryFactory().Create();

            #region Data Seeding
            noteRepository.Create(new Note("Git", "Learn Git"), false);
            noteRepository.Create(new Note("RegEx", "Learn RegEx"), false);
            noteRepository.Create(new Note("TDD", "Learn TDD"), false);
            noteRepository.Save();
            #endregion

            NoteRepository = noteRepository;
            NoteBuilder = new NoteBuilder();
        }

        public TransactionScope Transaction { get; set; }
        public INoteRepository NoteRepository { get; set; }
        public NoteBuilder NoteBuilder { get; set; }

        public void Dispose()
        {
            NoteRepository.Dispose();
            Transaction.Dispose();
        }
    }
}

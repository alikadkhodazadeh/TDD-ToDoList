namespace ToDoList.Persistence.Tests.Integration;

public sealed class NoteFixture : IDisposable
{
    public NoteFixture()
    {
        Transaction = new TransactionScope();
        NoteRepository = new NoteRepositoryFactory().CreateRepository();
        NoteBuilder = new NoteBuilder();

        #region Data Seeding
        NoteRepository.Create(NoteBuilder.WithTitle("Git").WithDescription("Learn Git").Build(), false);
        NoteRepository.Create(NoteBuilder.WithTitle("RegEx").WithDescription("Learn RegEx").Build(), false);
        NoteRepository.Create(NoteBuilder.WithTitle("TDD").WithDescription("Learn TDD").Build(), false);
        NoteRepository.Save();
        #endregion
    }

    public TransactionScope Transaction { get; set; }
    public INoteRepository NoteRepository { get; set; }
    public NoteBuilder NoteBuilder { get; set; }

    public void Dispose()
    {
        Transaction.Dispose();
        NoteRepository.Dispose();
    }
}

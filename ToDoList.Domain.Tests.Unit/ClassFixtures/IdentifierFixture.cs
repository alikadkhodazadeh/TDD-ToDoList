namespace ToDoList.Domain.Tests.Unit.ClassFixtures;

public class IdentifierFixture : IDisposable
{
    public IdentifierFixture()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    public void Dispose()
    {
        Id = Guid.Empty;
    }
}

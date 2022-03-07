namespace ToDoList.Domain
{
    public class Note
    {
        public Note(string? title, string? description)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;

            TitleValidator(); DescriptionValidator();
        }

        public Guid Id { get; private init; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public void TitleValidator()
        {
            if (string.IsNullOrEmpty(Title))
                throw new InvalidOperationException();
        }
        public void DescriptionValidator()
        {
            if (string.IsNullOrEmpty(Description))
                throw new InvalidOperationException();
        }
    }
}
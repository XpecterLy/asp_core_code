namespace TeamTask.Domain.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public bool IsCompleted { get; private set; }
        public Guid TaskListId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal TaskEntity(Guid taskListId, string title, string? description, DateTime? dueDate)
        {
            Id = Guid.NewGuid();
            TaskListId = taskListId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

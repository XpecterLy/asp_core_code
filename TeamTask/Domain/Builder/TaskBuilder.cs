using TeamTask.Domain.Entities;
using TeamTask.Domain.Models;

namespace TeamTask.Domain.Builder
{
    public class TaskBuilder
    {
        private Guid _taskListId;
        private string? _title;
        private string? _description;
        private DateTime? _dueDate;

        public TaskBuilder WithTaskListId(Guid taskListId)
        {
            _taskListId = taskListId;
            return this;
        }

        public TaskBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public TaskBuilder WithDescription(string? description)
        {
            _description = description;
            return this;
        }

        public TaskBuilder WithDueDate(DateTime? dueDate)
        {
            _dueDate = dueDate;
            return this;
        }

        public DtTask Build()
        {
            if (_taskListId == Guid.Empty)
                throw new ArgumentException("TaskListId is required.");
            if (string.IsNullOrWhiteSpace(_title))
                throw new ArgumentException("Title is required.");

            return new DtTask()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Descripcion = _description,
                DueDate = _dueDate,
                IsCompleted = false,
                Titulo = _title,
                TaskListId = _taskListId,
                UpdatedAt = DateTime.UtcNow,    
            };
        }
    }
}

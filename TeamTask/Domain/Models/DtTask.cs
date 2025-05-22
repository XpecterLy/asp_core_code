using System;
using System.Collections.Generic;

namespace TeamTask.Domain.Models;

public partial class DtTask
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public Guid TaskListId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual DtTaskList TaskList { get; set; } = null!;
}

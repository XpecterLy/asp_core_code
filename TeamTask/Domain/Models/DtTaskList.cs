using System;
using System.Collections.Generic;

namespace TeamTask.Domain.Models;

public partial class DtTaskList
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string UserNit { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<DtTask> DtTasks { get; set; } = new List<DtTask>();

    public virtual DtUser UserNitNavigation { get; set; } = null!;
}

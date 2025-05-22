using System;
using System.Collections.Generic;

namespace TeamTask.Domain.Models;

public partial class DtUser
{
    public string Nit { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<DtTaskList> DtTaskLists { get; set; } = new List<DtTaskList>();
}

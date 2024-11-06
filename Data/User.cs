using System;
using System.Collections.Generic;

namespace MovieSearchBackend.Data;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Biography { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual Role? Role { get; set; }
}

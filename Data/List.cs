using System;
using System.Collections.Generic;

namespace MovieSearchBackend.Data;

public partial class List
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<ListMovie> ListMovies { get; set; } = new List<ListMovie>();

    public virtual User User { get; set; } = null!;
}

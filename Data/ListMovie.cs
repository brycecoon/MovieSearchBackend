using System;
using System.Collections.Generic;

namespace MovieSearchBackend.Data;

public partial class ListMovie
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public int MovieId { get; set; }

    public virtual List List { get; set; } = null!;
}

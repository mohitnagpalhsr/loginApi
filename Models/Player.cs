using System;
using System.Collections.Generic;

namespace Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? PlayerName { get; set; }

    public int? Age { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? SportsName { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Participation> Participations { get; } = new List<Participation>();
}

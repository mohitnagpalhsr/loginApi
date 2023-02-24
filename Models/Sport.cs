using System;
using System.Collections.Generic;

namespace Models;

public partial class Sport
{
    public int SportsId { get; set; }

    public int? NoOfPlayers { get; set; }

    public string? SportsName { get; set; }

    public string? SportsType { get; set; }

    public virtual ICollection<Participation> Participations { get; } = new List<Participation>();
}

using System;
using System.Collections.Generic;

namespace Models;

public partial class Participation
{
    public int ParticipationId { get; set; }

    public int? PlayerId { get; set; }

    public string? PlayerName { get; set; }

    public int? EventId { get; set; }

    public string? EventName { get; set; }

    public int? SportsId { get; set; }

    public string? SportsName { get; set; }

    public string? Status { get; set; }

    public string? Comments { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Player? Player { get; set; }

    public virtual Sport? Sports { get; set; }
}

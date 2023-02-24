using System;
using System.Collections.Generic;

namespace Models;

public partial class Event
{
    public int EventId { get; set; }

    public DateTime? EventDate { get; set; }

    public string? EventName { get; set; }

    public int? NoofSlots { get; set; }

    public string? SportsName { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Participation> Participations { get; } = new List<Participation>();
}

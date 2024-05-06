﻿using System;
using System.Collections.Generic;

namespace MHSAlumni.Models;

public class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; }

    public DateTime EventDate { get; set; }

    public string EventLocation { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Registration> Registrations { get; } = new List<Registration>();
}

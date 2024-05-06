using System;
using System.Collections.Generic;

namespace MHSAlumni.Models;

public class Registration
{
    public int RegistrationId { get; set; }

    public DateTime? RegistrationInfo { get; set; }

    public int? EventId { get; set; }

    public int? AlumniId { get; set; }

    public virtual Alumnus Alumni { get; set; }

    public virtual Event Event { get; set; }
}

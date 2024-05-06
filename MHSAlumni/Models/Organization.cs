using System;
using System.Collections.Generic;

namespace MHSAlumni.Models;

public class Organization
{
    public int OrganizationId { get; set; }

    public string OrganizationName { get; set; }

    public string OrganizationType { get; set; }

    public virtual ICollection<Alumnus> Alumni { get; } = new List<Alumnus>();
}

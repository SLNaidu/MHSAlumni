using System;
using System.Collections.Generic;

namespace MHSAlumni.Models;

public  class Membership
{
    public int MembershipId { get; set; }

    public string MembershipType { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string GiftType { get; set; }

    public string GiftDedication { get; set; }

    public decimal? Payment { get; set; }

    public virtual ICollection<Alumnus> Alumni { get; } = new List<Alumnus>();
}

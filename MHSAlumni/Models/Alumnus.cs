using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MHSAlumni.Models;

public class Alumnus
{
    [Key]
    public int AlumniId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MaidenName { get; set; }

    public string HomePhonenumber { get; set; }

    public string WorkPhonenumber { get; set; }
    public string CellPhoneNumber { get; set; }

    public string Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }

    public string GraduationYear { get; set; }

    public string Organizations { get; set; }

    public string Occupation { get; set; }

    public string MaritalStatus { get; set; }
    public string Password { get; set; }

    public int? MembershipId { get; set; }

    public int? OrganizationId { get; set; }

    public virtual Membership Membership { get; set; }

    public virtual Organization Organization { get; set; }

    public virtual ICollection<Registration> Registrations { get; } = new List<Registration>();
}

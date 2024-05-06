
using Microsoft.EntityFrameworkCore;
using MHSAlumni.Models;
using System.Collections.Generic;

namespace MHSAlumni.DAL
{
    public class MhsaluminiContext : DbContext
    {
        public MhsaluminiContext(DbContextOptions<MhsaluminiContext> options) : base(options) { }
        public virtual DbSet<Alumnus> Alumni { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Membership> Memberships { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<Registration> Registrations { get; set; }


    }
}



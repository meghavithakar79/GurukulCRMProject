using Gurukul.Infrastructure.Models;
using Gurukul.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Gurukul.Infrastructure.Data
{
    public class GurukulDbContext : IdentityDbContext<AppUser, AppRole, int,IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public GurukulDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<EventAttendance> EventAttendances { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Mail> Mails { get; set; }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
           base.OnModelCreating(builder);
        }

    }
}

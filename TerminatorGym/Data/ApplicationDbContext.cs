using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TerminatorGym.Models;

namespace TerminatorGym.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TerminatorGym.Models.Miembro> Miembro { get; set; } = default!;
        public DbSet<TerminatorGym.Models.Membresia> Membresia { get; set; } = default!;
    }
}
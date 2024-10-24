using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ECC_API.Models
{
    public class ECCDbContext : DbContext
    {
        public ECCDbContext(DbContextOptions<ECCDbContext> options) : base(options) { }

        public DbSet<Administrator> Administrator { get; set; }  // Adding Administrators DbSet
        public DbSet<Students> Students { get; set; }
        public DbSet<FundingGuide> FundingGuide { get; set; }
        public DbSet<BusinessProposal> BusinessProposal { get; set; }
        public DbSet<Mentor> Mentor { get; set; }  // Add Mentor DbSet

        public DbSet<BusinessProposalUpload> BusinessProposalUploads { get; set; }


    }

    public class Administrator
    {
        [Key]
        public int AdminID { get; set; } // Mark this as the primary key
       // public int AdminID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class Mentor
    {
        [Key]
        public int MentorID { get; set; } // Primary Key
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

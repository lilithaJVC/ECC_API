﻿using Microsoft.EntityFrameworkCore;

namespace ECC_API.Models
{
    public class ECCDbContext : DbContext
    {
        public ECCDbContext(DbContextOptions<ECCDbContext> options) : base(options) { }

        public DbSet<Students> Students { get; set; }
        public DbSet<FundingGuide> FundingGuide { get; set; }
        public DbSet<BusinessProposal> BusinessProposal { get; set; }  
    }
}

using BloodDonation.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Data
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
        {
        }

        public DbSet<DonationCandidate> DonationCandidates { get; set; }
    }

}

using Microsoft.EntityFrameworkCore;

namespace EnquiryAPI.Model
{
    public class EnquiryDbContext:DbContext
    {
        public EnquiryDbContext(DbContextOptions<EnquiryDbContext> options) : base(options) 
        {

        }

        // connect Database Table with Models

        public DbSet<EnquiryStatus> EnquiryStatus { get; set; }
        public DbSet<EnquiryType> EnquiryType { get; set; }
        public DbSet<EnquiryModel> EnquiryModel { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace EnquiryAPI.Model
{
    public class EnquiryDbContext:DbContext
    {
        public EnquiryDbContext(DbContextOptions<EnquiryDbContext> options) : base(options) 
        {

        }
    }
}

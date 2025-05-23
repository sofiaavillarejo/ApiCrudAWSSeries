using ApiCrudAWSSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcAWSSeriesELB.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
    }
}

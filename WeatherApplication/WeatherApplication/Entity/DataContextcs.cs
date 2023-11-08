using Microsoft.EntityFrameworkCore;

namespace WeatherApplication.Entity
{
    public class DataContextcs :DbContext
    {
        public DataContextcs(DbContextOptions<DataContextcs> options) : base(options)
        {

        }

        
        public DbSet<Results> Results { get; set; }
    }
}


using BlazorWasm.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasm.API.Data
{
    public class DataContext : DbContext
    {
        /*public IConfiguration _config {  get; set; }
        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }*/
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet <Item> Items {get; set; }
        public DbSet <UnitOfMeasurement> UnitOfMeasurements { get; set; }
    }
}

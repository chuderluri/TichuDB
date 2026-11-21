using Microsoft.EntityFrameworkCore;

namespace TichuCounter.Data;

public class TichuCounterDbContext : DbContext
{
    public TichuCounterDbContext(DbContextOptions<TichuCounterDbContext> options) : base(options)
    {
    }
}

using Microsoft.EntityFrameworkCore;
using TichuCounter.Model.Entity;
using TichuCounter.Util;

namespace TichuCounter.Data;

public class TichuCounterDbContext : DbContext
{
    private readonly IAuditNameProvider _auditNameProvider;
    private readonly TimeProvider _timeProvider;

    public TichuCounterDbContext(
        DbContextOptions options,
        IAuditNameProvider auditNameProvider,
        TimeProvider timeProvider
    ) : base(options)
    {
        _auditNameProvider = auditNameProvider;
        _timeProvider = timeProvider;
    }

    public DbSet<GameEntity> Games => Set<GameEntity>();

    public override int SaveChanges()
    {
        SetBaseProperties();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseProperties();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetBaseProperties()
    {
        var entities = ChangeTracker.Entries().Where(x => x is { Entity: BaseEntity, State: EntityState.Added or EntityState.Modified });
        var utcNow = _timeProvider.GetUtcNow();
        var username = _auditNameProvider.GetAuditName();

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity) entity.Entity).Created = utcNow;
                ((BaseEntity) entity.Entity).CreatedBy = username;
            }

            ((BaseEntity) entity.Entity).Updated = utcNow;
            ((BaseEntity) entity.Entity).UpdatedBy = username;
            ((BaseEntity) entity.Entity).RowVersion += 1;
        }
    }
}

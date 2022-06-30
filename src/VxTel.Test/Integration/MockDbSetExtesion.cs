using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;
using VxTel.Domain.Entity;

namespace VxTel.Test.Integration
{
    public static class MockDbSetExtesion <T>
        where T : BaseEntity
    {
        public static ValueTask<EntityEntry<T>> GetEntityEntry(T entityResult)
        {
            var internalEntityEntry = new InternalEntityEntry(new Mock<IStateManager>().Object,
                new RuntimeEntityType(typeof(T).Name, typeof(T), false, new RuntimeModel(), null, null, ChangeTrackingStrategy.Snapshot, null, false), entityResult);

            var entityEntry = new EntityEntry<T>(internalEntityEntry);

            return new ValueTask<EntityEntry<T>>(entityEntry);
        }
    }
}

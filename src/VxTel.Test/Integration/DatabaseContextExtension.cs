using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VxTel.Infrastructure.Database;

namespace VxTel.Test.Integration
{
    public static class DatabaseContextExtension
    {
        public static DatabaseContext GetDatabaseContextTestAsync()
        {
            var _contextOptions = new DbContextOptionsBuilder<DatabaseContext>()
               .UseInMemoryDatabase("vxtel")
               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
               .Options;

            var databaseContext = new DatabaseContext(_contextOptions);
            databaseContext.Database.EnsureDeleted();
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
    }
}

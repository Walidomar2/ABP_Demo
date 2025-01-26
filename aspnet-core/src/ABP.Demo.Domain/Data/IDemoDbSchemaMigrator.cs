using System.Threading.Tasks;

namespace ABP.Demo.Data;

public interface IDemoDbSchemaMigrator
{
    Task MigrateAsync();
}

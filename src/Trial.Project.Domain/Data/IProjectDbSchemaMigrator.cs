using System.Threading.Tasks;

namespace Trial.Project.Data;

public interface IProjectDbSchemaMigrator
{
    Task MigrateAsync();
}

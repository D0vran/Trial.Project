using Volo.Abp.Modularity;

namespace Trial.Project;

public abstract class ProjectApplicationTestBase<TStartupModule> : ProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

using Volo.Abp.Modularity;

namespace Trial.Project;

[DependsOn(
    typeof(ProjectDomainModule),
    typeof(ProjectTestBaseModule)
)]
public class ProjectDomainTestModule : AbpModule
{

}

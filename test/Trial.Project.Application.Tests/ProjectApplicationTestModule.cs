using Volo.Abp.Modularity;

namespace Trial.Project;

[DependsOn(
    typeof(ProjectApplicationModule),
    typeof(ProjectDomainTestModule)
)]
public class ProjectApplicationTestModule : AbpModule
{

}

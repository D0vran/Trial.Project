using Trial.Project.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Trial.Project.Blazor;

public abstract class ProjectComponentBase : AbpComponentBase
{
    protected ProjectComponentBase()
    {
        LocalizationResource = typeof(ProjectResource);
    }
}

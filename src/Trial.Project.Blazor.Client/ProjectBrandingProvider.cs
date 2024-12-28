using Microsoft.Extensions.Localization;
using Trial.Project.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Trial.Project.Blazor.Client;

[Dependency(ReplaceServices = true)]
public class ProjectBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ProjectResource> _localizer;

    public ProjectBrandingProvider(IStringLocalizer<ProjectResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}

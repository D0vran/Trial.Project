using Trial.Project.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Trial.Project.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProjectController : AbpControllerBase
{
    protected ProjectController()
    {
        LocalizationResource = typeof(ProjectResource);
    }
}

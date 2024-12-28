using Trial.Project.Samples;
using Xunit;

namespace Trial.Project.EntityFrameworkCore.Applications;

[Collection(ProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProjectEntityFrameworkCoreTestModule>
{

}

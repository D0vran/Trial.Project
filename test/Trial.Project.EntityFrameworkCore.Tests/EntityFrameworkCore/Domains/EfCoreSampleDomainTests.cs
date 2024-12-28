using Trial.Project.Samples;
using Xunit;

namespace Trial.Project.EntityFrameworkCore.Domains;

[Collection(ProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProjectEntityFrameworkCoreTestModule>
{

}

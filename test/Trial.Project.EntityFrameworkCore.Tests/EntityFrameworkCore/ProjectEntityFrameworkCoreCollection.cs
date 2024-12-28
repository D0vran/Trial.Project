using Xunit;

namespace Trial.Project.EntityFrameworkCore;

[CollectionDefinition(ProjectTestConsts.CollectionDefinitionName)]
public class ProjectEntityFrameworkCoreCollection : ICollectionFixture<ProjectEntityFrameworkCoreFixture>
{

}

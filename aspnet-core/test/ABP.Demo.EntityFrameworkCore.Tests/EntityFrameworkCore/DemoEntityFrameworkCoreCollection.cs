using Xunit;

namespace ABP.Demo.EntityFrameworkCore;

[CollectionDefinition(DemoTestConsts.CollectionDefinitionName)]
public class DemoEntityFrameworkCoreCollection : ICollectionFixture<DemoEntityFrameworkCoreFixture>
{

}

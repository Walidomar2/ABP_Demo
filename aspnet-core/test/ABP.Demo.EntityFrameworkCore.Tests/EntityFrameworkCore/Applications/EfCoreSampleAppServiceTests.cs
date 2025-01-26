using ABP.Demo.Samples;
using Xunit;

namespace ABP.Demo.EntityFrameworkCore.Applications;

[Collection(DemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<DemoEntityFrameworkCoreTestModule>
{

}

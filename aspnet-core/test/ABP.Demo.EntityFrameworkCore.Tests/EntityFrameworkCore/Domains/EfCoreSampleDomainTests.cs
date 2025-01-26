using ABP.Demo.Samples;
using Xunit;

namespace ABP.Demo.EntityFrameworkCore.Domains;

[Collection(DemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<DemoEntityFrameworkCoreTestModule>
{

}

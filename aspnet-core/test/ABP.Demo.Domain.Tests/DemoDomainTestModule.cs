using Volo.Abp.Modularity;

namespace ABP.Demo;

[DependsOn(
    typeof(DemoDomainModule),
    typeof(DemoTestBaseModule)
)]
public class DemoDomainTestModule : AbpModule
{

}

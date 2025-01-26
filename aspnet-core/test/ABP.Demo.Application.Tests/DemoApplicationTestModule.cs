using Volo.Abp.Modularity;

namespace ABP.Demo;

[DependsOn(
    typeof(DemoApplicationModule),
    typeof(DemoDomainTestModule)
)]
public class DemoApplicationTestModule : AbpModule
{

}

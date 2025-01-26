using Volo.Abp.Modularity;

namespace ABP.Demo;

public abstract class DemoApplicationTestBase<TStartupModule> : DemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

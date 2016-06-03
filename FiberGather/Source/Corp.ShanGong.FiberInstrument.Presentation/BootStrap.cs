using Autofac;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.ProjectSpec;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    internal class BootStrap
    {
        public static IContainer CreateProjectContainer()
        {
            var container = new ContainerBuilder();
            container.Register(c => new PhysicalCalculatorSpecSW()).As<IPhysicalCalculator>();
            container.Register(c => new UrlServiceTransfer()).As<IDataPersistence>();
            var result = container.Build();
            return result;
        }
    }
}
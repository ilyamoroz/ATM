using ATM.Interfaces;
using Autofac;

namespace ATM.Dependencies
{
    public class CodeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PINCodeRepository>().As<IPINCodeRepository>();
        }
    }
}
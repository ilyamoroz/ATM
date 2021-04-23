using ATM.Interfaces;
using Autofac;

namespace ATM.Dependencies
{
    public class ATMServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ATMRepository>().As<IATMRepository>();
        }
    }
}
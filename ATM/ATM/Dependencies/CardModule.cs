using ATM.Interfaces;
using Autofac;

namespace ATM.Dependencies
{
    public class CardModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CardRepository>().As<ICardRepository>();
        }
    }
}
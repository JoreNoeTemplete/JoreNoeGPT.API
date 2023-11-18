using Autofac;
using JoreNoe;
using JoreNoe.Extend;
using JoreNoe.DB.EntityFrameWork.Core.SqlServer;
namespace JoreNoeBackTemplete.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JoreNoeBackTempleteRegister>().As<ICurrencyRegister>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginManager>().As<ILoginService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfLoginDal>().As<ILoginDal>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<DatabasesManager>().As<IDatabasesService>();
            builder.RegisterType<EfDatabasesDal>().As<IDatabasesDal>();


            builder.RegisterType<LicenceManager>().As<ILicenceService>();
            builder.RegisterType<EfLicenceDal>().As<ILicenceDal>();

            builder.RegisterType<LocalsManager>().As<ILocalsService>();
            builder.RegisterType<EfLocalsDal>().As<ILocalsDal>();

            builder.RegisterType<RolesManager>().As<IRolesService>();
            builder.RegisterType<EfRolesDal>().As<IRolesDal>();

            builder.RegisterType<RoleDetailManager>().As<IRoleDetailService>();
            builder.RegisterType<EfRoleDetailDal>().As<IRoleDetailDal>();

            builder.RegisterType<UsersManager>().As<IUsersService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

         
        }
    }
}

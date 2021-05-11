using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region firma-sube-lisans 

            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<CompanyLocalManager>().As<ICompanyLocalService>();
            builder.RegisterType<EfCompanyLocalDal>().As<ICompanyLocalDal>();

            #endregion

            #region Kullanici

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfCompanyOperationClaimDal>().As<ICompanyOperationClaimDal>();

            builder.RegisterType<CompanyUserOperationClaimManager>().As<ICompanyUserOperationClaimService>();
            builder.RegisterType<EfCompanyUserOperationClaimDal>().As<ICompanyUserOperationClaimDal>();

            builder.RegisterType<CompanyUsersManager>().As<ICompanyUserService>();
            builder.RegisterType<EfCompanyUserDal>().As<ICompanyUserDal>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            //  builder.RegisterType<EfUserDal>().As<IUserDal>();


            #endregion


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()

            }).SingleInstance();


        }
    }
}

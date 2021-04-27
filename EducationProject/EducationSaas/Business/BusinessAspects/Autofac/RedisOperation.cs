﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Redis;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace Business.BusinessAspects.Autofac
{
    public class RedisOperation : MethodInterception
    {
        private IRedisCacheService _redisCacheService;

        public RedisOperation(int duration = 60)
        {
            _redisCacheService = ServiceTool.ServiceProvider.GetService<IRedisCacheService>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var argument = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", argument.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_redisCacheService.IsAdd(key))
            {
                var test = invocation.TargetType.Name;
                if (key == "Business.Abstract.ICompanyService.GetList()")
                {
                    //string value = _redisCacheService.Get(key);
                    //invocation.ReturnValue = _redisCacheService.Get<SuccessDataResult<List<Company>>>(key);//null geliyor kontrol et
                    //return;
                }
            }
            invocation.Proceed();
            _redisCacheService.Set(key, invocation.ReturnValue);//, TimeSpan.FromTicks(_duration)
        }
    }
}
